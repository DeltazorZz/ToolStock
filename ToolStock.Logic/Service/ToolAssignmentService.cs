using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolStock.Data;
using ToolStock.Data.Models;
using ToolStock.Logic.DTOs;

namespace ToolStock.Logic.Service
{
    public class ToolAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public ToolAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToolAssignmentDTO>> GetToolAssignmentsAsync()
        {
            return await _context.ToolAssignments
                .Include(ta => ta.Tool)
                .Include(ta => ta.User)
                .Select(ta => new ToolAssignmentDTO
                {
                    Id = ta.Id,
                    ToolId = ta.ToolId,
                    UserId = ta.UserId,
                    DateOut = ta.DateOut,
                    DateIn = ta.DateIn,
                    Status = ta.Status,
                    LastUpdated = ta.LastUpdated
                }).ToListAsync();
        }

        public async Task<ToolAssignmentDTO?> GetToolAssignmentByIdAsync(int id)
        {
            return await _context.ToolAssignments
                .Include(ta => ta.Tool)
                .Include(ta => ta.User)
                .Where(ta => ta.Id == id)
                .Select(ta => new ToolAssignmentDTO
                {
                    Id = ta.Id,
                    ToolId = ta.ToolId,
                    UserId = ta.UserId,
                    DateOut = ta.DateOut,
                    DateIn = ta.DateIn,
                    Status = ta.Status,
                    LastUpdated = ta.LastUpdated
                }).FirstOrDefaultAsync();
        }

        public async Task<ToolAssignmentDTO> CreateToolAssignmentAsync(int toolId, int userId)
        {
            var newAssignment = new ToolAssignment
            {
                ToolId = toolId,
                UserId = userId,
                DateOut = DateTime.UtcNow,
                Status = "Assigned",
                LastUpdated = DateTime.UtcNow
            };

            _context.ToolAssignments.Add(newAssignment);
            await _context.SaveChangesAsync();

            return new ToolAssignmentDTO
            {
                Id = newAssignment.Id,
                ToolId = newAssignment.ToolId,
                UserId = newAssignment.UserId,
                DateOut = newAssignment.DateOut,
                DateIn = newAssignment.DateIn,
                Status = newAssignment.Status,
                LastUpdated = newAssignment.LastUpdated
            };
        }

        public async Task<bool> UpdateToolAssignmentAsync(int id, ToolAssignmentDTO dto)
        {
            var assignment = await _context.ToolAssignments.FindAsync(id);
            if (assignment == null) return false;

            assignment.Status = dto.Status;
            assignment.DateIn = dto.DateIn;
            assignment.LastUpdated = DateTime.UtcNow;

            _context.Entry(assignment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteToolAssignmentAsync(int id)
        {
            var assignment = await _context.ToolAssignments.FindAsync(id);
            if (assignment == null) return false;

            _context.ToolAssignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ToolAssignmentDTO?> GetToolIdByNameAsync(int id)
        {
            return await _context.ToolAssignments
                .Include(ta => ta.Tool)
                .Include(ta => ta.User)
                .Where(ta => ta.Id == id)
                .Select(ta => new ToolAssignmentDTO
                {
                    Id = ta.Id,
                    ToolId = ta.ToolId,
                    UserId = ta.UserId,
                    DateOut = ta.DateOut,
                    DateIn = ta.DateIn,
                    Status = ta.Status,
                    LastUpdated = ta.LastUpdated
                }).FirstOrDefaultAsync();
        }

        public async Task<int?> GetToolIdByNameAsync(string toolName)
        {
            var tool = await _context.Tools
                .Where(t => t.Name.Equals(toolName, StringComparison.OrdinalIgnoreCase))  
                .FirstOrDefaultAsync();

            return tool?.Id;  
        }

        public async Task<int?> GetUserIdByNameAsync(string userName)
        {
            var user = await _context.Users
                .Where(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase))  
                .FirstOrDefaultAsync();

            return user?.Id;  
        }

        public async Task<string?> GetToolNameByIdAsync(int toolId)
        {
            var tool = await _context.Tools
                .Where(t => t.Id == toolId)
                .FirstOrDefaultAsync();

            return tool?.Name;
        }
        public async Task<string?> GetUserNameByIdAsync(int userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            return user?.Name;  
        }
    }
}
