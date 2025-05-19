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
    public class WorkoutSessionController : ControllerBase
    {
        private readonly IWorkoutSessionService _sessionService;

        public WorkoutSessionController(IWorkoutSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // POST: api/workoutsession
        [HttpPost]
        public async Task<IActionResult> LogWorkoutSession([FromBody] LogWorkoutSessionDto dto, [FromQuery] Guid groupId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Extract userId from token and groupId from query params
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

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
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);
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
