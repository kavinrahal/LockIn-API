using System.ComponentModel.DataAnnotations;

namespace LockIn_API.DTOs
{
    public class WorkoutSessionDto
    {
        public Guid SessionId { get; set; }
        public Guid RoutineId { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public DateTime SessionDate { get; set; }
        public string? Notes { get; set; }
        public List<WorkoutSessionExerciseDto> SessionExercises { get; set; } = new List<WorkoutSessionExerciseDto>();
        // Collection of congratulatory messages for performance improvement.
        public List<string> CongratulatoryMessages { get; set; } = new List<string>();
    }

    public class WorkoutSessionExerciseDto
    {
        public Guid SessionExerciseId { get; set; }
        public Guid ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int ActualSets { get; set; }
        public int ActualReps { get; set; }
        public float? ActualWeight { get; set; }
    }

    public class LogWorkoutSessionDto
    {
        [Required]
        public Guid RoutineId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        public string? Notes { get; set; }

        [Required]
        public List<AddWorkoutSessionExerciseDto> Exercises { get; set; } = new List<AddWorkoutSessionExerciseDto>();
    }

    public class AddWorkoutSessionExerciseDto
    {
        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int ActualSets { get; set; }

        [Required]
        public int ActualReps { get; set; }

        public float? ActualWeight { get; set; }
    }
}
