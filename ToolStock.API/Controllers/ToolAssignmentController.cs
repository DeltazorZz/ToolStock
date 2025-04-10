using Microsoft.AspNetCore.Mvc;
using ToolStock.API.ViewModels;
using ToolStock.Logic.DTOs;
using ToolStock.Logic.Service;

namespace ToolStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolAssignmentController : ControllerBase
    {
        private readonly ToolAssignmentService _toolAssignmentService;
    
        public ToolAssignmentController(ToolAssignmentService toolAssignmentService)
        {
            _toolAssignmentService = toolAssignmentService;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolAssignmentViewModel>>> GetToolAssignments()
        {
            var assignments = await _toolAssignmentService.GetToolAssignmentsAsync();
    
            var response = await Task.WhenAll(assignments.Select(async a => new ToolAssignmentViewModel
            {
    
    
                UserName = await _toolAssignmentService.GetUserNameByIdAsync(a.UserId),
                ToolName = await _toolAssignmentService.GetToolNameByIdAsync(a.ToolId),
                DateOut = a.DateOut,
                DateIn = a.DateIn,
                Status = a.Status,
                LastUpdated = a.LastUpdated
            }).ToList());
    
            return Ok(response);
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolAssignmentViewModel>> GetToolAssignment(int id)
        {
            var assignment = await _toolAssignmentService.GetToolAssignmentByIdAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }
    
        [HttpPost]
        public async Task<ActionResult<ToolAssignmentViewModel>> PostToolAssignment(ToolAssignmentViewModel model)
        {
            var userId = await _toolAssignmentService.GetUserIdByNameAsync(model.UserName) ?? 0;
            var toolId = await _toolAssignmentService.GetToolIdByNameAsync(model.ToolName) ?? 0;
            if (userId == 0 || toolId == 0)
            {
                return BadRequest("User or Tool not found.");
            }
    
            var dto = new ToolAssignmentDTO
            {
                UserId = userId,
                ToolId = toolId,
                DateOut = model.DateOut,
                DateIn = model.DateIn,
                Status = model.Status,
                LastUpdated = DateTime.UtcNow
            };
    
            var createdAssignment = await _toolAssignmentService.CreateToolAssignmentAsync(dto.ToolId, dto.UserId);
    
            return CreatedAtAction(nameof(GetToolAssignment), new { id = createdAssignment.Id }, new ToolAssignmentViewModel
            {
                UserName = model.UserName,
                ToolName = model.ToolName,
                DateOut = createdAssignment.DateOut,
                DateIn = createdAssignment.DateIn,
                Status = createdAssignment.Status,
                LastUpdated = createdAssignment.LastUpdated
            });
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToolAssignment(int id, ToolAssignmentViewModel model)
        {
            var userId = await _toolAssignmentService.GetUserIdByNameAsync(model.UserName) ?? 0;
            var toolId = await _toolAssignmentService.GetToolIdByNameAsync(model.ToolName) ?? 0;
            if (userId == 0 || toolId == 0)
            {
                return BadRequest("User or Tool not found.");
            }
    
            var dto = new ToolAssignmentDTO
            {
                UserId = userId,
                ToolId = toolId,
                DateOut = model.DateOut,
                DateIn = model.DateIn,
                Status = model.Status,
                LastUpdated = DateTime.UtcNow
            };
    
            var updated = await _toolAssignmentService.UpdateToolAssignmentAsync(id, dto);
    
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
