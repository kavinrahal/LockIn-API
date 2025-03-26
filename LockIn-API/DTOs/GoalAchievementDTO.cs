namespace LockIn_API.DTOs
{
    public class GoalAchievementDto
    {
        public Guid AchievementId { get; set; }
        public Guid GroupMemberGoalId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public bool Achieved { get; set; }
        public int? ActualValue { get; set; }
        public int? TargetValue { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
