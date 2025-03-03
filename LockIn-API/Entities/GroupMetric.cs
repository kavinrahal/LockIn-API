using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class GroupMetric
    {
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public Guid MetricId { get; set; }
        [ForeignKey("MetricId")]
        public Metric Metric { get; set; }
    }
}
