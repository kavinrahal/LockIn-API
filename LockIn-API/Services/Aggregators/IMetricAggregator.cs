namespace LockIn_API.Services.Aggregators
{
    public interface IMetricAggregator
    {
        Task<int> GetAggregatedValueAsync(Guid userId, Guid groupId, DateTime periodStart, DateTime periodEnd, Guid? workoutRoutineId = null);
    }
}
