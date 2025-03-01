using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IWorkoutSessionService
    {
        Task<WorkoutSessionDto> LogWorkoutSessionAsync(LogWorkoutSessionDto dto, Guid userId, Guid groupId);
        Task<IEnumerable<WorkoutSessionDto>> GetWorkoutSessionsAsync(Guid userId, Guid groupId);
    }
}
