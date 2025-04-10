//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToolStock.Data;
//using Microsoft.EntityFrameworkCore;
//using ToolStock.Logic.DTO;
//using ToolStock.Data.Models;

//namespace ToolStock.Logic.Service
//{
//    public class CustomerService
//    {
//        private readonly ApplicationDbContext _context;

//        public CustomerService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<CustomerDTO>> GetCustomersAsync()
//        {
//            return await _context.Customers
//                .Select(c => new CustomerDTO
//                {
//                    Id = c.Id,
//                    CompanyName = c.CompanyName,
//                    CompanyAddress = c.CompanyAddress,
//                    CompanyTaxIdentifier = c.CompanyTaxIdentifier,
//                }).ToListAsync();
//        }

//        public async Task<CustomerDTO?> GetCustomerByIdAsync(int id)
//        {
//            return await _context.Customers
//                .Where(c => c.Id == id)
//                .Select(c => new CustomerDTO
//                {
//                    Id = c.Id,
//                    CompanyName = c.CompanyName,
//                    CompanyAddress = c.CompanyAddress,
//                    CompanyTaxIdentifier = c.CompanyTaxIdentifier,
//                }).FirstOrDefaultAsync();
//        }
//        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto)
//        {
//            var newCustomer = new Customer { CompanyName = dto.CompanyName, CompanyAddress = dto.CompanyAddress, CompanyTaxIdentifier = dto.CompanyTaxIdentifier };
//            _context.Customers.Add(newCustomer);
//            await _context.SaveChangesAsync();

//            return new CustomerDTO {
//                Id = newCustomer.Id,
//                CompanyName = newCustomer.CompanyName,
//                CompanyAddress = newCustomer.CompanyAddress,
//                CompanyTaxIdentifier = newCustomer.CompanyTaxIdentifier,
//            };
//        }

//        public async Task<bool> UpdateCategoryAsync(int id, CustomerDTO dto)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null) return false;

//            customer.Id = dto.Id;
//            customer.CompanyName = dto.CompanyName;
//            customer.CompanyAddress = dto.CompanyAddress;
//            customer.CompanyTaxIdentifier = dto.CompanyTaxIdentifier;
//            _context.Entry(customer).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteCategoryAsync(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null) return false;

//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//    }
//}
