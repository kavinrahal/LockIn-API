using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class GoalAchievement
    {
        [Key]
        public Guid AchievementId { get; set; }

        [Required]
        public Guid GroupMemberGoalId { get; set; }
        [ForeignKey("GroupMemberGoalId")]
        public GroupMemberGoal? GroupMemberGoal { get; set; }

        [Required]
        public DateTime PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        [Required]
        public bool Achieved { get; set; }

        public int? ActualValue { get; set; }

        public int? TargetValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
