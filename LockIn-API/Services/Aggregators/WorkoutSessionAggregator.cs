
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LockIn_API.Services.Aggregators
{
    public class WorkoutSessionAggregator : IMetricAggregator
    {
        private readonly ApplicationDbContext _context;

        public WorkoutSessionAggregator(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetAggregatedValueAsync(Guid userId, Guid groupId, DateTime periodStart, DateTime periodEnd, Guid? workoutRoutineId = null)
        {
            var routine = await _context.WorkoutRoutines
            .Include(r => r.RoutineExercises)
            .FirstOrDefaultAsync(r =>
                r.UserId == userId &&
                r.GroupId == groupId &&
                (workoutRoutineId == null || r.RoutineId == workoutRoutineId));

            if (routine == null || !routine.RoutineExercises.Any()) return 0;

            var session = await _context.WorkoutSessions
            .Include(s => s.SessionExercises)
            .FirstOrDefaultAsync(s =>
                s.UserId == userId &&
                s.GroupId == groupId &&
                s.SessionDate >= periodStart &&
                s.SessionDate <= periodEnd);
        }
    }
}
