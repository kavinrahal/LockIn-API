using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class WorkoutSession
    {
        [Key]
        public Guid SessionId { get; set; }

        [Required]
        public Guid RoutineId { get; set; }
        [ForeignKey("RoutineId")]
        public WorkoutRoutine WorkoutRoutine { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        public string? Notes { get; set; }

        public ICollection<WorkoutSessionExercise> SessionExercises { get; set; } = new List<WorkoutSessionExercise>();
    }
}
