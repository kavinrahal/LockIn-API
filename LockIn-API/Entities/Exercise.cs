using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class Exercise
    {
        [Key]
        public Guid ExerciseId { get; set; }
        [Required]
        public string ExerciseName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;  // e.g., "cardio", "strength"
        public string Equipment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
