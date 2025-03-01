using LockIn_API.DTOs;
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class WorkoutRoutineService : IWorkoutRoutineService
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRoutineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutRoutineDto> AddRoutineExerciseAsync(Guid routineId, CreateRoutineExerciseDto dto, Guid userId)
        {
            var routine = await _context.WorkoutRoutines.FirstOrDefaultAsync(r => r.RoutineId == routineId && r.UserId == userId);
            if (routine == null)
                throw new Exception("Workout routine not found or you are not authorized.");

            var routineExercise = new RoutineExercise
            {
                RoutineExerciseId = Guid.NewGuid(),
                RoutineId = routineId,
                DayNumber = dto.DayNumber,
                ExerciseId = dto.ExerciseId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                Weight = dto.Weight,
                CreatedAt = DateTime.UtcNow
            };

            _context.RoutineExercises.Add(routineExercise);
            await _context.SaveChangesAsync();

            return await GetWorkoutRoutineAsync(routineId);
        }

        public async Task<WorkoutRoutineDto> CreateWorkoutRoutineAsync(CreateWorkoutRoutineDto dto, Guid userId, Guid groupId)
        {
            var routine = new WorkoutRoutine
            {
                RoutineId = Guid.NewGuid(),
                RoutineName = dto.RoutineName,
                TotalDays = dto.TotalDays,
                UserId = userId,
                GroupId = groupId,
                CreatedAt = DateTime.UtcNow
            };

            _context.WorkoutRoutines.Add(routine);
            await _context.SaveChangesAsync();

            return await GetWorkoutRoutineAsync(routine.RoutineId);
        }

        public async Task<WorkoutRoutineDto> GetWorkoutRoutineAsync(Guid routineId)
        {
            var routine = await _context.WorkoutRoutines
                .Include(r => r.RoutineExercises)
                    .ThenInclude(re => re.Exercise)
                .FirstOrDefaultAsync(r => r.RoutineId == routineId);

            if (routine == null)
                throw new Exception("Workout routine not found.");

            return new WorkoutRoutineDto
            {
                RoutineId = routine.RoutineId,
                RoutineName = routine.RoutineName,
                TotalDays = routine.TotalDays,
                CreatedAt = routine.CreatedAt,
                RoutineExercises = routine.RoutineExercises.Select(re => new RoutineExerciseDto
                {
                    RoutineExerciseId = re.RoutineExerciseId,
                    DayNumber = re.DayNumber,
                    ExerciseId = re.ExerciseId,
                    ExerciseName = re.Exercise.ExerciseName,
                    Sets = re.Sets,
                    Reps = re.Reps,
                    Weight = re.Weight
                }).ToList()
            };
        }
    }
}
