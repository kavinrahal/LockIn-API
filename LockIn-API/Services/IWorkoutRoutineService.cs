using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IWorkoutRoutineService
    {
        Task<WorkoutRoutineDto> CreateWorkoutRoutineAsync(CreateWorkoutRoutineDto dto, Guid userId, Guid groupId);
        Task<WorkoutRoutineDto> AddRoutineExerciseAsync(Guid routineId, CreateRoutineExerciseDto dto, Guid userId);
        Task<WorkoutRoutineDto> GetWorkoutRoutineAsync(Guid routineId);
    }
}
