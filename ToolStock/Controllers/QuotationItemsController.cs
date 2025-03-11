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
    public class QuotationItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuotationItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuotationItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuotationItem>>> GetQuotationItems()
        {
            return await _context.QuotationItems.ToListAsync();
        }

        // GET: api/QuotationItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationItem>> GetQuotationItem(int id)
        {
            var quotationItem = await _context.QuotationItems.FindAsync(id);

            if (quotationItem == null)
            {
                return NotFound();
            }

            return quotationItem;
        }

        // PUT: api/QuotationItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotationItem(int id, QuotationItem quotationItem)
        {
            if (id != quotationItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(quotationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotationItemExists(id))
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

        // POST: api/QuotationItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuotationItem>> PostQuotationItem(QuotationItem quotationItem)
        {
            _context.QuotationItems.Add(quotationItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotationItem", new { id = quotationItem.Id }, quotationItem);
        }

        // DELETE: api/QuotationItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotationItem(int id)
        {
            var quotationItem = await _context.QuotationItems.FindAsync(id);
            if (quotationItem == null)
            {
                return NotFound();
            }

            _context.QuotationItems.Remove(quotationItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuotationItemExists(int id)
        {
            return _context.QuotationItems.Any(e => e.Id == id);
        }
    }
}
