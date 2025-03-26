
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services.Aggregators
{
    public class WaterIntakeAggregator : IMetricAggregator
    {
        private readonly ApplicationDbContext _context;

        public WaterIntakeAggregator(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetAggregatedValueAsync(Guid userId, Guid groupId, DateTime periodStart, DateTime periodEnd, Guid? workoutRoutineId)
        {
            var totalSteps = await _context.WaterIntakes
                .Where(s => s.UserId == userId &&
                            s.GroupId == groupId &&
                            s.Date >= periodStart && s.Date <= periodEnd)
                .SumAsync(s => (int?)s.Liters) ?? 0;
            return totalSteps;
        }
    }
}
