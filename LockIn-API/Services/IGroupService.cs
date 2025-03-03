using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IGroupService
    {
        Task<GroupDetailsDto> CreateGroupAsync(CreateGroupDto dto, Guid adminUserId);
        Task JoinGroupAsync(JoinGroupDto dto, Guid userId);
        Task<GroupDetailsDto> GetGroupDetailsAsync(Guid groupId);
        Task<IEnumerable<GroupDetailsDto>> GetUserGroupsAsync(Guid userId);
    }
}
