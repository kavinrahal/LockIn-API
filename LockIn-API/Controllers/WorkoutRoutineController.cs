using LockIn_API.DTOs;
using LockIn_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LockIn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkoutRoutineController : ControllerBase
    {
        private readonly IWorkoutRoutineService _routineService;

        public WorkoutRoutineController(IWorkoutRoutineService routineService)
        {
            _routineService = routineService;
        }

        // POST: api/workoutroutine
        [HttpPost]
        public async Task<IActionResult> CreateWorkoutRoutine([FromBody] CreateWorkoutRoutineDto dto, [FromQuery] Guid groupId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Extract userId and groupId from query params
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var routineDto = await _routineService.CreateWorkoutRoutineAsync(dto, userId, groupId);
                return Ok(routineDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/workoutroutine/{routineId}/exercise
        [HttpPost("{routineId}/exercise")]
        public async Task<IActionResult> AddRoutineExercise(Guid routineId, [FromBody] CreateRoutineExerciseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);
            try
            {
                var updatedRoutine = await _routineService.AddRoutineExerciseAsync(routineId, dto, userId);
                return Ok(updatedRoutine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/workoutroutine/{routineId}
        [HttpGet("{routineId}")]
        public async Task<IActionResult> GetWorkoutRoutine(Guid routineId)
        {
            try
            {
                var routine = await _routineService.GetWorkoutRoutineAsync(routineId);
                return Ok(routine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
