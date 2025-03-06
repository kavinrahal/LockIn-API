using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }

        [Required]
        public string GroupName { get; set; } = string.Empty;

        [Required]
        public Guid AdminId { get; set; }

        [ForeignKey("AdminId")]
        public User Admin { get; set; }

        [Required]
        public string UpdateFrequency { get; set; } = string.Empty; // e.g., "weekly", "fortnightly"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public ICollection<GroupMemberGoal> GroupMemberGoals { get; set; } = new List<GroupMemberGoal>();
        public ICollection<GroupMemberGoalHistory> GroupMemberGoalHistories { get; set; } = new List<GroupMemberGoalHistory>();
        public ICollection<GroupMetric> GroupMetrics { get; set; } = new List<GroupMetric>();
        public ICollection<WorkoutRoutine> WorkoutRoutines { get; set; } = new List<WorkoutRoutine>();
        public ICollection<DietLog> DietLogs { get; set; } = new List<DietLog>();
        public ICollection<WaterIntake> WaterIntakes { get; set; } = new List<WaterIntake>();
        public ICollection<StepTracking> StepTrackings { get; set; } = new List<StepTracking>();
        public ICollection<WorkoutSession> WorkoutSessions { get; set; }


    }
}
