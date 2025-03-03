using LockIn_API.DTOs;
using LockIn_API.Entities;
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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // POST: api/group - Create a new group.
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Extract userId from the token's "sub" claim.
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);


            try
            {
                var groupDetails = await _groupService.CreateGroupAsync(dto, userId);
                return Ok(groupDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/group/join - Join an existing group.
        [HttpPost("join")]
        public async Task<IActionResult> JoinGroup([FromBody] JoinGroupDto dto)
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
                await _groupService.JoinGroupAsync(dto, userId);
                return Ok("Successfully joined the group.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/group/{groupId} - Get group details.
        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroupDetails(Guid groupId)
        {
            try
            {
                var groupDetails = await _groupService.GetGroupDetailsAsync(groupId);
                return Ok(groupDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/group/user - Get all groups for the current user.
        [HttpGet("user")]
        public async Task<IActionResult> GetUserGroups()
        {
            var subClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (subClaim == null)
            {
                throw new Exception("User ID (sub claim) not found in token.");
            }
            var userId = Guid.Parse(subClaim.Value);

            try
            {
                var groups = await _groupService.GetUserGroupsAsync(userId);
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
