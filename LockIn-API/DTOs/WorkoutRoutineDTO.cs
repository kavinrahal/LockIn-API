using System.ComponentModel.DataAnnotations;

namespace LockIn_API.DTOs
{
    public class WorkoutRoutineDto
    {
        public Guid RoutineId { get; set; }
        public string RoutineName { get; set; }
        public int TotalDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<RoutineExerciseDto> RoutineExercises { get; set; } = new List<RoutineExerciseDto>();
    }

    public class RoutineExerciseDto
    {
        public Guid RoutineExerciseId { get; set; }
        public int DayNumber { get; set; }
        public Guid ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float? Weight { get; set; }
    }

    public class CreateWorkoutRoutineDto
    {
        [Required]
        public string RoutineName { get; set; }

        [Required]
        public int TotalDays { get; set; }
    }

    public class CreateRoutineExerciseDto
    {
        [Required]
        public int DayNumber { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }

        public float? Weight { get; set; }
    }
}
