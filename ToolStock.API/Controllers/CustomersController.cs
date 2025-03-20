using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolStock.API.ViewModels.Post_Put_RequestViews;
using ToolStock.Data;
using ToolStock.Data.Models;
using ToolStock.Logic.ViewModels.Get_RequestViews;
using ToolStock.Logic.ViewModels.Post_Put_RequestViews;

namespace ToolStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicatonDbContext _context;

        public CustomersController(ApplicatonDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.Select(c => new CustomerViewModel
            {
                CompanyName = c.CompanyName,
                CompanyAddress = c.CompanyAddress,
                CompanyTaxIdentifier = c.CompanyTaxIdentifier
            }).ToListAsync();

            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id).Select(c => new CustomerViewModel {
                CompanyName = c.CompanyName,
                CompanyAddress = c.CompanyAddress,
                CompanyTaxIdentifier = c.CompanyTaxIdentifier
            }).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerInputViewModel model)
        {

            var customer = await _context.Customers.FindAsync(id);


            if (customer == null)
            {
                return NotFound();
            }
            customer.CompanyName = model.CompanyName;
            customer.CompanyAddress = model.CompanyAddress;
            customer.CompanyTaxIdentifier = model.CompanyTaxIdentifier;

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerInputViewModel model)
        {
            var customer = new Customer
            {
                CompanyName = model.CompanyName,
                CompanyAddress = model.CompanyAddress,
                CompanyTaxIdentifier = model.CompanyTaxIdentifier,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Customer), new { id = customer.Id }, new CustomerViewModel { 
                CompanyName = customer.CompanyName, 
                CompanyAddress = customer.CompanyAddress, 
                CompanyTaxIdentifier = customer.CompanyTaxIdentifier, 
            });
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
