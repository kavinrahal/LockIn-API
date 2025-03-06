using System.ComponentModel.DataAnnotations;

namespace LockIn_API.DTOs
{

    public class GroupMemberGoalDto
    {
        public Guid GoalId { get; set; }
        public Guid GroupId { get; set; }
        public Guid MetricId { get; set; }
        public int? GoalValue { get; set; }
        public Guid? WorkoutRoutineId { get; set; }
        public string MetricName { get; set; } 
        public string DataType { get; set; }      
        public DateTime CreatedAt { get; set; }
    }
    public class SetGroupMemberGoalDto
    {
        [Required]
        public Guid GroupId { get; set; }

        [Required]
        public Guid MetricId { get; set; }

        public int? GoalValue { get; set; }

        public Guid? WorkoutRoutineId { get; set; }
    }


}
