using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStock.Data;
using ToolStock.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data.Models;

namespace ToolStock.Logic.Service
{
    public class ToolService
    {
        private readonly ApplicationDbContext _context;

        public ToolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToolDTO>> GetToolsAsync()
        {
            return await _context.Tools
                .Select(t => new ToolDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    SerialNumber = t.SerialNumber,
                    Status = t.Status,
                    PurchaseDate = t.PurchaseDate,
                    LastMaintenance = t.LastMaintenance,
                }).ToListAsync();
        }
        public async Task<ToolDTO?> GetToolByIdAsync(int id)
        {
            return await _context.Tools
                .Where(t => t.Id == id)
                .Select(t => new ToolDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    SerialNumber = t.SerialNumber,
                    Status = t.Status,
                    PurchaseDate = t.PurchaseDate,
                    LastMaintenance = t.LastMaintenance,
                }).FirstOrDefaultAsync();
        }
        public async Task<ToolDTO> CreateToolAsync(ToolDTO dto)
        {
            var newTool = new Tool
            {Name = dto.Name, SerialNumber = dto.SerialNumber, Status = dto.Status, PurchaseDate = dto.PurchaseDate, LastMaintenance = dto.LastMaintenance};
            _context.Tools.Add(newTool);
            await _context.SaveChangesAsync();

            return new ToolDTO
            {
                Id = newTool.Id,
                Name = newTool.Name,
                SerialNumber = newTool.SerialNumber,
                Status = newTool.Status,
                PurchaseDate = newTool.PurchaseDate,
                LastMaintenance = newTool.LastMaintenance,
            };
        }

        public async Task<bool> UpdateToolAsync(int id, ToolDTO dto)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) return false;

            tool.Name = dto.Name;
            tool.SerialNumber = dto.SerialNumber;
            tool.Status = dto.Status;
            tool.PurchaseDate = dto.PurchaseDate;
            tool.LastMaintenance = dto.LastMaintenance;
            _context.Entry(tool).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteToolAsync(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) return false;

            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
