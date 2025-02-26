namespace LockIn_API.Entities
{
    public class Metric
    {
        public Guid MetricId { get; set; }
        public string Name { get; set; } = string.Empty;         // e.g., "Steps", "Diet", "Water", "Workout Routine"
        public string Description { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
    }
}
