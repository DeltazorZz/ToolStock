using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStock.Data;
using ToolStock.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data.Models;
using ToolStock.Logic.DTOs;

namespace ToolStock.Logic.Service
{
    public class MaterialService
    {
        private readonly ApplicationDbContext _context;

        public MaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaterialDTO>> GetMaterialsAsync()
        {
            return await _context.Materials
                .Select(m => new MaterialDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Quantity = m.Quantity,
                    Unit = m.Unit,
                    PricePerUnit = m.PricePerUnit,
                    MinStockLevel = m.MinStockLevel,
                    LastUpdated = m.LastUpdated,
                }).ToListAsync();
        }

        public async Task<MaterialDTO?> GetMaterialByIdAsync(int id)
        {
            return await _context.Materials
                .Where(m => m.Id == id)
                .Select(m => new MaterialDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Quantity = m.Quantity,
                    Unit = m.Unit,
                    PricePerUnit = m.PricePerUnit,
                    MinStockLevel = m.MinStockLevel,
                    LastUpdated = m.LastUpdated,
                }).FirstOrDefaultAsync();
        }
        

        public async Task<MaterialDTO> CreateMaterialAsync(MaterialDTO dto)
        {
            var newMaterial = new Material {Name = dto.Name, Quantity = dto.Quantity, Unit = dto.Unit, PricePerUnit = dto.PricePerUnit, MinStockLevel = dto.MinStockLevel, LastUpdated = dto.LastUpdated,};
            _context.Materials.Add(newMaterial);
            await _context.SaveChangesAsync();

            return new MaterialDTO
            {
                Id = newMaterial.Id,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                PricePerUnit = dto.PricePerUnit,
                MinStockLevel = dto.MinStockLevel,
                LastUpdated = dto.LastUpdated,
            };
        }


        public async Task<bool> UpdateMaterialAsync(int id, MaterialDTO dto)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return false;

            material.Name = dto.Name;
            material.Quantity = dto.Quantity;
            material.Unit = dto.Unit;
            material.PricePerUnit = dto.PricePerUnit;
            material.MinStockLevel = dto.MinStockLevel;
            material.LastUpdated = dto.LastUpdated;
            _context.Entry(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return false;

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
