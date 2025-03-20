using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data;
using ToolStock.Data.Models;
using ToolStock.Logic.Service;
using ToolStock.Logic.ViewModels.Get_RequestViews;
using ToolStock.Logic.ViewModels.Post_Put_RequestViews;

namespace ToolStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoriesController(CategoryService service)
        {
            categoryService = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await categoryService.GetCategoriesAsync();

            var categoryViewModel = categories.Select(c => new CategoryViewModel { 
                Name = c.Name,
                Type = c.Type    
            }).ToList();

            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }


            var categoryViewModel = new CategoryViewModel {
                Name = category.Name,
                Type = category.Type
            };

            
            return Ok(categoryViewModel);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryInputViewModel model)
        {
            var update = await categoryService.UpdateCategoryAsync(id, model.Name, model.Type)
            if (!update) return NotFound();
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryInputViewModel model)
        {
            var category = await categoryService.CreateCategoryAsync(model.Name, model.Type);

            var response = new CategoryViewModel
            {
                Name = category.Name,
                Type = category.Type,
            };



            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, response);

            
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var delete = await categoryService.DeleteCategoryAsync(id);
            if (!delete) return NotFound();
            return NoContent();
        }


    }
}
