using LockIn_API.DTOs;
using LockIn_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockIn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSessionService _sessionService;

        public WorkoutSessionController(IWorkoutSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // POST: api/workoutsession
        [HttpPost]
        public async Task<IActionResult> LogWorkoutSession([FromBody] LogWorkoutSessionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Extract userId from token and groupId from query params
            var userId = Guid.Parse(User.FindFirst("sub")?.Value);
            if (!Guid.TryParse(Request.Query["groupId"], out Guid groupId))
                return BadRequest("GroupId is required in query parameters.");

            try
            {
                var sessionDto = await _sessionService.LogWorkoutSessionAsync(dto, userId, groupId);
                return Ok(sessionDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/workoutsession?groupId={groupId}
        [HttpGet]
        public async Task<IActionResult> GetWorkoutSessions([FromQuery] Guid groupId)
        {
            var userId = Guid.Parse(User.FindFirst("sub")?.Value);
            try
            {
                var sessions = await _sessionService.GetWorkoutSessionsAsync(userId, groupId);
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
