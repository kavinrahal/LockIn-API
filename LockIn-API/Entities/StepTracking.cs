using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockIn_API.Entities
{
    public class StepTracking
    {
        [Key]
        public Guid StepId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public int StepCount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
