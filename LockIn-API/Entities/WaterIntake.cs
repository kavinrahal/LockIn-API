using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockIn_API.Entities
{
    public class WaterIntake
    {
        [Key]
        public Guid WaterId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public float Liters { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
