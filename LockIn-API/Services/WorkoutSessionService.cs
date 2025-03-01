using LockIn_API.DTOs;
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly ApplicationDbContext _context;

        public WorkoutSessionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WorkoutSessionDto>> GetWorkoutSessionsAsync(Guid userId, Guid groupId)
        {
            var sessions = await _context.WorkoutSessions
                .Include(ws => ws.SessionExercises)
                    .ThenInclude(se => se.Exercise)
                .Where(ws => ws.UserId == userId && ws.GroupId == groupId)
                .ToListAsync();

            return sessions.Select(s => MapWorkoutSessionToDto(s));
        }

        public async Task<WorkoutSessionDto> LogWorkoutSessionAsync(LogWorkoutSessionDto dto, Guid userId, Guid groupId)
        {
            // Create a new workout session record
            var session = new WorkoutSession
            {
                SessionId = Guid.NewGuid(),
                RoutineId = dto.RoutineId,
                UserId = userId,
                GroupId = groupId,
                SessionDate = dto.SessionDate,
                Notes = dto.Notes
            };

            // Add each exercise performance to the session
            foreach (var exDto in dto.Exercises)
            {
                var sessionExercise = new WorkoutSessionExercise
                {
                    SessionExerciseId = Guid.NewGuid(),
                    SessionId = session.SessionId,
                    ExerciseId = exDto.ExerciseId,
                    ActualSets = exDto.ActualSets,
                    ActualReps = exDto.ActualReps,
                    ActualWeight = exDto.ActualWeight
                };

                session.SessionExercises.Add(sessionExercise);
            }

            _context.WorkoutSessions.Add(session);
            await _context.SaveChangesAsync();

            // List to collect congratulatory messages
            List<string> messages = new List<string>();

            // For each exercise in the session, check for improvement
            foreach (var sessionExercise in session.SessionExercises)
            {
                var message = await UpdatePlannedTargetIfImproved(dto.RoutineId, sessionExercise, dto.SessionDate, userId);
                if (!string.IsNullOrEmpty(message))
                {
                    messages.Add(message);
                }
            }

            // Retrieve the session with its exercise details
            var loggedSession = await _context.WorkoutSessions
                .Include(ws => ws.SessionExercises)
                    .ThenInclude(se => se.Exercise)
                .FirstOrDefaultAsync(ws => ws.SessionId == session.SessionId);

            var resultDto = MapWorkoutSessionToDto(loggedSession);
            resultDto.CongratulatoryMessages = messages;
            return resultDto;
        }

        private WorkoutSessionDto MapWorkoutSessionToDto(WorkoutSession session)
        {
            if (session == null)
                throw new Exception("Workout session not found.");

            return new WorkoutSessionDto
            {
                SessionId = session.SessionId,
                RoutineId = session.RoutineId,
                UserId = session.UserId,
                GroupId = session.GroupId,
                SessionDate = session.SessionDate,
                Notes = session.Notes,
                SessionExercises = session.SessionExercises.Select(se => new WorkoutSessionExerciseDto
                {
                    SessionExerciseId = se.SessionExerciseId,
                    ExerciseId = se.ExerciseId,
                    ExerciseName = se.Exercise.ExerciseName,
                    ActualSets = se.ActualSets,
                    ActualReps = se.ActualReps,
                    ActualWeight = se.ActualWeight
                }).ToList(),
                CongratulatoryMessages = new List<string>()
            };
        }

        /// <summary>
        /// Compares the current session exercise with the most recent previous one for the same routine and exercise.
        /// If improved, updates the planned target in RoutineExercise and returns a congratulatory message.
        /// </summary>
        private async Task<string?> UpdatePlannedTargetIfImproved(Guid routineId, WorkoutSessionExercise currentExercise, DateTime sessionDate, Guid userId)
        {
            // Retrieve the most recent previous session for the same routine and exercise
            var previousSessionExercise = await _context.WorkoutSessionExercises
                .Include(se => se.WorkoutSession)
                .Where(se => se.WorkoutSession.RoutineId == routineId &&
                             se.ExerciseId == currentExercise.ExerciseId &&
                             se.WorkoutSession.UserId == userId &&
                             se.WorkoutSession.SessionDate < sessionDate)
                .OrderByDescending(se => se.WorkoutSession.SessionDate)
                .FirstOrDefaultAsync();

            if (previousSessionExercise != null)
            {
                bool improved = false;
                // Check if either reps or weight improved
                if (currentExercise.ActualReps > previousSessionExercise.ActualReps)
                    improved = true;
                else if (currentExercise.ActualWeight.HasValue && previousSessionExercise.ActualWeight.HasValue &&
                         currentExercise.ActualWeight.Value > previousSessionExercise.ActualWeight.Value)
                    improved = true;

                if (improved)
                {
                    // Update the planned target in RoutineExercise
                    var plannedExercise = await _context.RoutineExercises
                        .FirstOrDefaultAsync(re => re.RoutineId == routineId && re.ExerciseId == currentExercise.ExerciseId);
                    if (plannedExercise != null)
                    {
                        plannedExercise.Sets = currentExercise.ActualSets;
                        plannedExercise.Reps = currentExercise.ActualReps;
                        plannedExercise.Weight = currentExercise.ActualWeight;
                        await _context.SaveChangesAsync();
                    }
                    return $"Great job on {currentExercise.Exercise.ExerciseName}! Your performance improved (Reps: {previousSessionExercise.ActualReps} -> {currentExercise.ActualReps}).";
                }
            }
            return null;
        }
    }
}
