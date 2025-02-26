namespace LockIn_API.Entities
{
    public class WorkoutRoutine
    {
        public Guid RoutineId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string RoutineName { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<RoutineExercise> RoutineExercises { get; set; }
    }
}
