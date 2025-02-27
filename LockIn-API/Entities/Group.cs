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
        public ICollection<GroupMember> GroupMembers { get; set; }

        public ICollection<GroupMemberGoal> GroupMemberGoals { get; set; }
        public ICollection<GroupMetric> GroupMetrics { get; set; }
        public ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
        public ICollection<DietLog> DietLogs { get; set; } = new List<DietLog>();
        public ICollection<WaterIntake> WaterIntakes { get; set; } = new List<WaterIntake>();
        public ICollection<StepTracking> StepTrackings { get; set; } = new List<StepTracking>();

        


    }
}
