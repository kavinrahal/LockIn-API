using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class WorkoutSessionExercise
    {
        [Key]
        public Guid SessionExerciseId { get; set; }

        [Required]
        public Guid SessionId { get; set; }
        [ForeignKey("SessionId")]
        public WorkoutSession WorkoutSession { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }

        [Required]
        public int ActualSets { get; set; }

        [Required]
        public int ActualReps { get; set; }

        public float? ActualWeight { get; set; }
    }
}
