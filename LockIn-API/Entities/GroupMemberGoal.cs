﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class GroupMemberGoal
    {
        [Key]
        public Guid GoalId { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid MetricId { get; set; }
        [ForeignKey("MetricId")]
        public Metric Metric { get; set; }

        // For numeric metrics
        public int? GoalValue { get; set; }

        // For complex metrics (e.g., Workout Routine)
        public Guid? WorkoutRoutineId { get; set; }
        [ForeignKey("WorkoutRoutineId")]
        public WorkoutRoutine? WorkoutRoutine { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
