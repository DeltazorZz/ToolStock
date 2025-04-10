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
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetMaterials()
        {
            var materials = await _materialService.GetMaterialsAsync();
            var response = materials.Select(m => new MaterialViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Quantity = m.Quantity,
                Unit = m.Unit,
                PricePerUnit = m.PricePerUnit,
                MinStockLevel = m.MinStockLevel,
                LastUpdated = m.LastUpdated,
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialViewModel>> GetMaterial(int id)
        {
            var material = await _materialService.GetMaterialByIdAsync(id);
            if (material == null) return NotFound();

            return Ok(new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                Quantity = material.Quantity,
                Unit = material.Unit,
                PricePerUnit = material.PricePerUnit,
                MinStockLevel = material.MinStockLevel,
                LastUpdated = material.LastUpdated,
            });
        }

        [HttpPost]
        public async Task<ActionResult<MaterialViewModel>> PostMaterial(MaterialViewModel model)
        {
            var dto = new MaterialDTO { Name = model.Name, Quantity = model.Quantity, Unit = model.Unit, PricePerUnit = model.PricePerUnit, MinStockLevel = model.MinStockLevel, LastUpdated = model.LastUpdated };
            var createdMaterial = await _materialService.CreateMaterialAsync(dto);

            return CreatedAtAction(nameof(GetMaterial), new { id = createdMaterial.Id }, new MaterialViewModel
            {
                Id = createdMaterial.Id,
                Name = createdMaterial.Name,
                Quantity = createdMaterial.Quantity,
                Unit = createdMaterial.Unit,
                PricePerUnit = createdMaterial.PricePerUnit,
                MinStockLevel = createdMaterial.MinStockLevel,
                LastUpdated = createdMaterial.LastUpdated,
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialViewModel model)
        {
            var dto = new MaterialDTO { Name = model.Name, Quantity = model.Quantity, Unit = model.Unit, PricePerUnit = model.PricePerUnit, MinStockLevel = model.MinStockLevel, LastUpdated = model.LastUpdated };
            var updated = await _materialService.UpdateMaterialAsync(id, dto);

            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _materialService.DeleteMaterialAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
