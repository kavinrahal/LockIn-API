using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class Metric
    {
        [Key]
        public Guid MetricId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;         // e.g., "Steps", "Diet", "Water", "Workout Routine"
        public string Description { get; set; } = string.Empty;
        [Required]
        public string DataType { get; set; } = string.Empty;
    }
}
