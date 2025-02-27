using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class RoutineExercise
    {
        [Key]
        public Guid RoutineExerciseId { get; set; }

        [Required]
        public Guid RoutineId { get; set; }
        [ForeignKey("RoutineId")]
        public WorkoutRoutine WorkoutRoutine { get; set; }

        [Required]
        public int DayNumber { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }

        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        public float? Weight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
