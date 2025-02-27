using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class WorkoutRoutine
    {
        [Key]
        public Guid RoutineId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public string RoutineName { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<RoutineExercise> RoutineExercises { get; set; }
    }
}
