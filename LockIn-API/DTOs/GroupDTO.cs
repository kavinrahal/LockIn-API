using System.ComponentModel.DataAnnotations;

namespace LockIn_API.DTOs
{
    public class GroupDetailsDto
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string UpdateFrequency { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MemberDto> Members { get; set; } = new List<MemberDto>();
    }

    public class MemberDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public DateTime JoinedAt { get; set; }
    }

    public class CreateGroupDto
    {
        [Required]
        public string GroupName { get; set; }

        [Required]
        public string UpdateFrequency { get; set; } 
    }

    public class JoinGroupDto
    {
        [Required]
        public Guid GroupId { get; set; }
    }


}
