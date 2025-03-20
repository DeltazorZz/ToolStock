using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data;
using ToolStock.Data.Models;

namespace ToolStock.Logic.Service
{
    public class CategoryService
    {
       
            private readonly ApplicatonDbContext _context;

            public CategoryService(ApplicatonDbContext context)
            {
                _context = context;
            }


            public async Task<List<Category>> GetCategoriesAsync()
            {
                return await _context.Categories.ToListAsync();
            }

            public async Task<Category> GetCategoryByIdAsync(int id)
            {

                return await _context.Categories.FindAsync(id);
            }


            public async Task<Category> CreateCategoryAsync(string name, string type)
            {
                var category = new Category { Name = name, Type = type };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }

            public async Task<bool> UpdateCategoryAsync(int id, string name, string type)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return false;

                category.Name = name;
                category.Type = type;
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
        }
            public async Task<bool> DeleteCategoryAsync(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return false;

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
        }

        }
}
