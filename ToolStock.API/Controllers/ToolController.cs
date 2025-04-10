using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolStock.API.ViewModels;
using ToolStock.Data.Models;
using ToolStock.Logic.DTOs;
using ToolStock.Logic.Service;

namespace ToolStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly ToolService _toolService;

        public ToolController(ToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolViewModel>>> GetTools()
        {
            var tools = await _toolService.GetToolsAsync();
            var response = tools.Select(t => new ToolViewModel
            {
                Id = t.Id,
                Name = t.Name,
                SerialNumber = t.SerialNumber,
                Status = t.Status,
                PurchaseDate = t.PurchaseDate,
                LastMaintenance = t.LastMaintenance,
            }).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToolViewModel>> GetTool(int id)
        {
            var tool = await _toolService.GetToolByIdAsync(id);
            if (tool == null) return NotFound();

            return Ok(new ToolViewModel
            {
                Id = tool.Id,
                Name = tool.Name,
                SerialNumber = tool.SerialNumber,
                Status = tool.Status,
                PurchaseDate = tool.PurchaseDate,
                LastMaintenance = tool.LastMaintenance,
            });
        }

        [HttpPost]
        public async Task<ActionResult<ToolViewModel>> PostTool(ToolViewModel model)
        {
            var dto = new ToolDTO {
                Name = model.Name,
                SerialNumber = model.SerialNumber,
                Status = model.Status,
                PurchaseDate = model.PurchaseDate,
                LastMaintenance = model.LastMaintenance,
            };
            var createdTool = await _toolService.CreateToolAsync(dto);

            return CreatedAtAction(nameof(GetTool), new { id = createdTool.Id }, new ToolViewModel
            {
                Id = createdTool.Id,
                Name = createdTool.Name,
                SerialNumber = createdTool.SerialNumber,
                Status = createdTool.Status,
                PurchaseDate = createdTool.PurchaseDate,
                LastMaintenance = createdTool.LastMaintenance,
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTool(int id, ToolViewModel model)
        {
            var dto = new ToolDTO {
                Name = model.Name,
                SerialNumber = model.SerialNumber,
                Status = model.Status,
                PurchaseDate = model.PurchaseDate,
                LastMaintenance = model.LastMaintenance,
            };
            var updated = await _toolService.UpdateToolAsync(id, dto);

            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id)
        {
            var deleted = await _toolService.DeleteToolAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

    }
}
