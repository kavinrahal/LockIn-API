using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IGroupMemberGoalService
    {
        Task<GroupMemberGoalDto> SetOrUpdateGoalAsync(SetGroupMemberGoalDto dto, Guid userId);
        Task<GroupMemberGoalDto> GetLatestGoalAsync(Guid groupId, Guid metricId, Guid userId);
        Task<IEnumerable<GroupMemberGoalDto>> GetGoalsForGroupAsync(Guid groupId, Guid userId);
    }
}
