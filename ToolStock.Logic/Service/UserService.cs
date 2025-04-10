using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStock.Data;
using Microsoft.EntityFrameworkCore;
using ToolStock.Logic.DTOs;
using ToolStock.Data.Models;
using System.Data;
using System.Numerics;


namespace ToolStock.Logic.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role,
                    Email = u.Email,
                    Phone = u.Phone,
                    LastUpdated = u.LastUpdated,
                }).ToListAsync();
        }
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {

                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role,
                    Email = u.Email,
                    Phone = u.Phone,
                    LastUpdated = u.LastUpdated,
                }).FirstOrDefaultAsync();
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDTO
                {

                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role,
                    Password = u.PasswordHash,
                    Email = u.Email,
                    Phone = u.Phone,
                    LastUpdated = u.LastUpdated,
                }).FirstOrDefaultAsync();
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO dto, string password)
        {
            var hashedPassword = HashPassword(password); 
            var newUser = new User
            {
                Name = dto.Name,
                Role = dto.Role,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Phone = dto.Phone,
                LastUpdated = DateTime.UtcNow,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Role = newUser.Role,
                Email = newUser.Email,
                Phone = newUser.Phone,
                LastUpdated = newUser.LastUpdated,
            };
        }
        public async Task<bool> UpdateUserAsync(int id, UserDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = dto.Name;
            user.Role = dto.Role;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.LastUpdated = dto.LastUpdated;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
