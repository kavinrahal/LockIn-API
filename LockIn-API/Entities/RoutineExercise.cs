namespace LockIn_API.Entities
{
    public class RoutineExercise
    {
        public Guid RoutineExerciseId { get; set; }
        public Guid RoutineId { get; set; }
        public WorkoutRoutine WorkoutRoutine { get; set; }
        public int DayNumber { get; set; }
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float? Weight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
