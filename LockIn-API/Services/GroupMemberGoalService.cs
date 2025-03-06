using LockIn_API.DTOs;
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class GroupMemberGoalService : IGroupMemberGoalService
    {
        private readonly ApplicationDbContext _context;

        public GroupMemberGoalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupMemberGoalDto>> GetGoalsForGroupAsync(Guid groupId, Guid userId)
        {
            var goals = await _context.GroupMemberGoals
                .Include(gmg => gmg.Metric)
                .Where(gmg => gmg.GroupId == groupId && gmg.UserId == userId)
                .OrderByDescending(gmg => gmg.CreatedAt)
                .ToListAsync();

            return goals.Select(MapToDto);
        }

        public async Task<GroupMemberGoalDto> GetLatestGoalAsync(Guid groupId, Guid metricId, Guid userId)
        {
            var goal = await _context.GroupMemberGoals
                .Include(gmg => gmg.Metric)
                .Where(gmg => gmg.GroupId == groupId &&
                              gmg.MetricId == metricId &&
                              gmg.UserId == userId)
                .OrderByDescending(gmg => gmg.CreatedAt)
                .FirstOrDefaultAsync();

            if (goal == null)
                throw new Exception("Goal not found.");

            return MapToDto(goal);
        }

        public async Task<GroupMemberGoalDto> SetOrUpdateGoalAsync(SetGroupMemberGoalDto dto, Guid userId)
        {
            var currentGoal = await _context.GroupMemberGoals
                .Include(gmg => gmg.Metric)
                .FirstOrDefaultAsync(gmg => gmg.GroupId == dto.GroupId &&
                                            gmg.MetricId == dto.MetricId &&
                                            gmg.UserId == userId);

            if (currentGoal != null)
            {
                // Archive the existing record.
                var historyRecord = new GroupMemberGoalHistory
                {
                    HistoryId = Guid.NewGuid(),
                    GroupMemberGoalId = currentGoal.GoalId,
                    GroupId = currentGoal.GroupId,
                    UserId = currentGoal.UserId,
                    MetricId = currentGoal.MetricId,
                    GoalValue = currentGoal.GoalValue,
                    WorkoutRoutineId = currentGoal.WorkoutRoutineId,
                    ArchivedAt = DateTime.UtcNow
                };

                _context.GroupMemberGoalHistories.Add(historyRecord);

                // Update the current goal with new values.
                currentGoal.GoalValue = dto.GoalValue;
                currentGoal.WorkoutRoutineId = dto.WorkoutRoutineId;
                currentGoal.CreatedAt = DateTime.UtcNow;

                _context.GroupMemberGoals.Update(currentGoal);
                await _context.SaveChangesAsync();
                return MapToDto(currentGoal);
            }
            else
            {
                // If no current goal exists, create a new one.
                var newGoal = new GroupMemberGoal
                {
                    GoalId = Guid.NewGuid(),
                    GroupId = dto.GroupId,
                    UserId = userId,
                    MetricId = dto.MetricId,
                    GoalValue = dto.GoalValue,
                    WorkoutRoutineId = dto.WorkoutRoutineId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.GroupMemberGoals.Add(newGoal);
                await _context.SaveChangesAsync();
                return MapToDto(newGoal);
            }
        }

        private GroupMemberGoalDto MapToDto(GroupMemberGoal goal)
        {
            return new GroupMemberGoalDto
            {
                GoalId = goal.GoalId,
                GroupId = goal.GroupId,
                MetricId = goal.MetricId,
                GoalValue = goal.GoalValue,
                WorkoutRoutineId = goal.WorkoutRoutineId,
                MetricName = goal.Metric?.Name ?? "Unknown",
                DataType = goal.Metric?.DataType ?? "Unknown",
                CreatedAt = goal.CreatedAt
            };
        }
    }
}
