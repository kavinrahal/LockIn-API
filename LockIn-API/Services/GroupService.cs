using LockIn_API.DTOs;
using LockIn_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class GroupService : IGroupService
    {

        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GroupDetailsDto> CreateGroupAsync(CreateGroupDto dto, Guid adminUserId)
        {
            var group = new Group
            {
                GroupId = Guid.NewGuid(),
                GroupName = dto.GroupName,
                AdminId = adminUserId,
                UpdateFrequency = dto.UpdateFrequency,
                CreatedAt = DateTime.UtcNow
            };

            _context.Groups.Add(group);

            // Add the creator as a member.
            var groupMember = new GroupMember
            {
                GroupId = group.GroupId,
                UserId = adminUserId,
                JoinedAt = DateTime.UtcNow
            };

            _context.GroupMembers.Add(groupMember);

            await _context.SaveChangesAsync();
            return await GetGroupDetailsAsync(group.GroupId);
        }

        public async Task<GroupDetailsDto> GetGroupDetailsAsync(Guid groupId)
        {
            var group = await _context.Groups
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.User)
                .FirstOrDefaultAsync(g => g.GroupId == groupId);

            if (group == null)
                throw new Exception("Group not found.");

            var dto = new GroupDetailsDto
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                UpdateFrequency = group.UpdateFrequency,
                CreatedAt = group.CreatedAt,
                Members = group.GroupMembers.Select(gm => new MemberDto
                {
                    UserId = gm.UserId,
                    FullName = gm.User.FullName,
                    JoinedAt = gm.JoinedAt
                }).ToList()
            };

            return dto;
        }

        public async Task<IEnumerable<GroupDetailsDto>> GetUserGroupsAsync(Guid userId)
        {
            var groups = await _context.GroupMembers
                .Where(gm => gm.UserId == userId)
                .Select(gm => gm.Group)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.User)
                .ToListAsync();

            return groups.Select(g => new GroupDetailsDto
            {
                GroupId = g.GroupId,
                GroupName = g.GroupName,
                UpdateFrequency = g.UpdateFrequency,
                CreatedAt = g.CreatedAt,
                Members = g.GroupMembers.Select(gm => new MemberDto
                {
                    UserId = gm.UserId,
                    FullName = gm.User.FullName,
                    JoinedAt = gm.JoinedAt
                }).ToList()
            }).ToList();
        }

        public async Task JoinGroupAsync(JoinGroupDto dto, Guid userId)
        {
            // Find the group by id.
            var group = await _context.Groups.FindAsync(dto.GroupId);
            if (group == null)
                throw new Exception("Group not found.");

            // Check if the user is already a member.
            var existingMember = await _context.GroupMembers.FindAsync(dto.GroupId, userId);
            if (existingMember != null)
                throw new Exception("User is already a member of this group.");

            var newMember = new GroupMember
            {
                GroupId = dto.GroupId,
                UserId = userId,
                JoinedAt = DateTime.UtcNow
            };

            _context.GroupMembers.Add(newMember);
            await _context.SaveChangesAsync();
        }
    }
}
