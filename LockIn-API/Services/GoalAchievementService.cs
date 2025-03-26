using LockIn_API.DTOs;
using LockIn_API.Entities;
using LockIn_API.Services.Aggregators;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class GoalAchievementService : IGoalAchievementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMetricAggregatorFactory _aggregatorFactory;

        public GoalAchievementService(ApplicationDbContext context, IMetricAggregatorFactory aggregatorFactory)
        {
            _context = context;
            _aggregatorFactory = aggregatorFactory;
        }
        public async Task<IEnumerable<GoalAchievementDto>> GetGoalAchievementsAsync(Guid groupId, Guid metricId, Guid userId)
        {
            // Join GoalAchievements with GroupMemberGoals so that we can filter by group, metric, and user.
            var achievements = await _context.GoalAchievements
                .Include(ga => ga.GroupMemberGoal)
                .Where(ga => ga.GroupMemberGoal.GroupId == groupId &&
                             ga.GroupMemberGoal.MetricId == metricId &&
                             ga.GroupMemberGoal.UserId == userId)
                .OrderByDescending(ga => ga.CreatedAt)
                .ToListAsync();

            return achievements.Select(MapToDto);
        }

        public async Task<GoalAchievementDto> RecordGoalAchievementAsync(Guid groupMemberGoalId, DateTime periodStart, DateTime periodEnd)
        {
            // Retrieve the current goal along with its associated Metric.
            var goal = await _context.GroupMemberGoals
                .Include(g => g.Metric)
                .FirstOrDefaultAsync(g => g.GoalId == groupMemberGoalId);
            if (goal == null)
                throw new Exception("Group member goal not found.");

            // Use the metric name to select the correct aggregator.
            IMetricAggregator aggregator = _aggregatorFactory.GetAggregator(goal.Metric.Name);
            int aggregatedValue = await aggregator.GetAggregatedValueAsync(goal.UserId, goal.GroupId, periodStart, periodEnd);

            bool achieved = goal.GoalValue.HasValue && aggregatedValue >= goal.GoalValue.Value;

            var achievement = new GoalAchievement
            {
                AchievementId = Guid.NewGuid(),
                GroupMemberGoalId = groupMemberGoalId,
                PeriodStart = periodStart,
                PeriodEnd = periodEnd,
                Achieved = achieved,
                ActualValue = aggregatedValue,
                TargetValue = goal.GoalValue,
                CreatedAt = DateTime.UtcNow
            };

            _context.GoalAchievements.Add(achievement);
            await _context.SaveChangesAsync();

            return MapToDto(achievement);
        }

        private GoalAchievementDto MapToDto(GoalAchievement achievement)
        {
            return new GoalAchievementDto
            {
                AchievementId = achievement.AchievementId,
                GroupMemberGoalId = achievement.GroupMemberGoalId,
                PeriodStart = achievement.PeriodStart,
                PeriodEnd = achievement.PeriodEnd,
                Achieved = achievement.Achieved,
                ActualValue = achievement.ActualValue,
                TargetValue = achievement.TargetValue,
                CreatedAt = achievement.CreatedAt
            };
        }
    }
}
