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
    public class GoalAchievementController : ControllerBase
    {
        private readonly IGoalAchievementService _achievementService;

        public GoalAchievementController(IGoalAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpPost]
        public async Task<IActionResult> RecordGoalAchievement([FromQuery] Guid groupMemberGoalId, [FromQuery] DateTime periodStart, [FromQuery] DateTime periodEnd)
        {
            try
            {
                var achievementDto = await _achievementService.RecordGoalAchievementAsync(groupMemberGoalId, periodStart, periodEnd);
                return Ok(achievementDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetGoalAchievements([FromQuery] Guid groupId, [FromQuery] Guid metricId)
        {
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var achievements = await _achievementService.GetGoalAchievementsAsync(groupId, metricId, userId);
                return Ok(achievements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
