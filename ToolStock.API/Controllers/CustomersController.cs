//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ToolStock.API.ViewModels;
//using ToolStock.Logic.DTO;
//using ToolStock.Logic.Service;


//namespace ToolStock.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        private readonly CustomerService _customerService;

//        public CustomersController(CustomerService customerService)
//        {
//            this._customerService = customerService;
//        }


//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetCategories()
//        {
//            var categories = await _customerService.GetCustomersAsync();
//            var response = categories.Select(c => new CustomerViewModel
//            {
//                CompanyName = c.CompanyName,
//                CompanyAddress = c.CompanyAddress,
//                CompanyTaxIdentifier = c.CompanyTaxIdentifier,
//            }).ToList();
//            return Ok(response);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<CustomerViewModel>> GetCustomer(int id)
//        {
//            var customer = await _customerService.GetCustomerByIdAsync(id);
//            if (customer == null) return NotFound();

//            return Ok(new CustomerViewModel {
//                CompanyName = customer.CompanyName,
//                CompanyAddress = customer.CompanyAddress,
//                CompanyTaxIdentifier = customer.CompanyTaxIdentifier,
//            });
//        }

//        [HttpPost]
//        public async Task<ActionResult<CustomerViewModel>> PostCategory(CustomerViewModel model)
//        {
//            var dto = new CustomerDTO { CompanyName = model.CompanyName, CompanyAddress = model.CompanyAddress, CompanyTaxIdentifier = model.CompanyTaxIdentifier };
//            var createdCustomer = await _customerService.CreateCustomerAsync(dto);

//            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, new CustomerViewModel
//            {
//                CompanyName = createdCustomer.CompanyName,
//                CompanyAddress = createdCustomer.CompanyAddress,
//                CompanyTaxIdentifier = createdCustomer.CompanyTaxIdentifier,
//            });
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCategory(int id, CustomerViewModel model)
//        {
//            var dto = new CustomerDTO { CompanyName = model.CompanyName, CompanyAddress = model.CompanyAddress, CompanyTaxIdentifier = model.CompanyTaxIdentifier };
//            var updated = await _customerService.UpdateCategoryAsync(id, dto);

//            if (!updated) return NotFound();

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCategory(int id)
//        {
//            var deleted = await _customerService.DeleteCategoryAsync(id);
//            if (!deleted) return NotFound();

//            return NoContent();
//        }
//    }
//}
