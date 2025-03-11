using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data;
using ToolStock.Models;

namespace ToolStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolAssignmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToolAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolAssignment>>> GetToolAssignments()
        {
            return await _context.ToolAssignments.ToListAsync();
        }

        // GET: api/ToolAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolAssignment>> GetToolAssignment(int id)
        {
            var toolAssignment = await _context.ToolAssignments.FindAsync(id);

            if (toolAssignment == null)
            {
                return NotFound();
            }

            return toolAssignment;
        }

        // PUT: api/ToolAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToolAssignment(int id, ToolAssignment toolAssignment)
        {
            if (id != toolAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(toolAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToolAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToolAssignment>> PostToolAssignment(ToolAssignment toolAssignment)
        {
            _context.ToolAssignments.Add(toolAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToolAssignment", new { id = toolAssignment.Id }, toolAssignment);
        }

        // DELETE: api/ToolAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToolAssignment(int id)
        {
            var toolAssignment = await _context.ToolAssignments.FindAsync(id);
            if (toolAssignment == null)
            {
                return NotFound();
            }

            _context.ToolAssignments.Remove(toolAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToolAssignmentExists(int id)
        {
            return _context.ToolAssignments.Any(e => e.Id == id);
        }
    }
}
