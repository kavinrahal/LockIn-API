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
    public class GroupMemberGoalController : ControllerBase
    {
        private readonly IGroupMemberGoalService _goalService;

        public GroupMemberGoalController(IGroupMemberGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpPost]
        public async Task<IActionResult> SetGoal([FromBody] SetGroupMemberGoalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Extract userId from the token's "sub" claim.
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var goalDto = await _goalService.SetOrUpdateGoalAsync(dto, userId);
                return Ok(goalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestGoal([FromQuery] Guid groupId, [FromQuery] Guid metricId)
        {
            // Extract userId from the token's "sub" claim.
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var goalDto = await _goalService.GetLatestGoalAsync(groupId, metricId, userId);
                return Ok(goalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetGoalsForGroup([FromQuery] Guid groupId)
        {
            // Extract userId from the token's "sub" claim.
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var goals = await _goalService.GetGoalsForGroupAsync(groupId, userId);
                return Ok(goals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
