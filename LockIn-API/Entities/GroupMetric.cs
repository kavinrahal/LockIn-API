namespace LockIn_API.Entities
{
    public class GroupMetric
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid MetricId { get; set; }
        public Metric Metric { get; set; }
    }
}
