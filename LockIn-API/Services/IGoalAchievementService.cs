using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IGoalAchievementService
    {
        Task<GoalAchievementDto> RecordGoalAchievementAsync(Guid groupMemberGoalId, DateTime periodStart, DateTime periodEnd);
        Task<IEnumerable<GoalAchievementDto>> GetGoalAchievementsAsync(Guid groupId, Guid metricId, Guid userId);
    }
}
