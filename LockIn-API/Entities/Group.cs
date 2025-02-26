namespace LockIn_API.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public Guid AdminId { get; set; }
        public string UpdateFrequency { get; set; } = string.Empty; // e.g., "weekly", "fortnightly"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User Admin { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<GroupMetric> GroupMetrics { get; set; }

    }
}
