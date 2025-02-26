using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LockIn_API.Entities
{
    public class User
    {
        [Key]
        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public string? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Navigation properties
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
    }
}
