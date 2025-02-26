namespace LockIn_API.Entities
{
    public class GroupMemberGoal
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid MetricId { get; set; }
        public Metric Metric { get; set; }

        // For simple numeric goals
        public int? GoalValue { get; set; }

        // For the workout routine metric, link to the detailed routine
        public Guid? WorkoutRoutineId { get; set; }
        public WorkoutRoutine? WorkoutRoutine { get; set; }
    }
}
