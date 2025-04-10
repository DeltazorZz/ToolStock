using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using ToolStock.API.ViewModels;
using ToolStock.Logic.DTOs;
using ToolStock.Logic.Service;


namespace ToolStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            var response = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Role = u.Role,
                Email = u.Email,
                Phone = u.Phone,
                LastUpdated = u.LastUpdated,
            }).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                Phone = user.Phone,
                LastUpdated = user.LastUpdated,
            });
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<UserViewModel>> GetUserbyemail([FromBody] string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null) return NotFound();

            return Ok(new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                Phone = user.Phone,
                LastUpdated = user.LastUpdated,
            });
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> RegisterUser(RegisterViewModel model)
        {
            

            var dto = new UserDTO
            {
                Name = model.Name,
                Role = model.Role,
                Email = model.Email,
                Phone = model.Phone,
                LastUpdated = DateTime.UtcNow
            };

            var createdUser = await _userService.CreateUserAsync(dto, model.Password);

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, new UserViewModel
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Role = createdUser.Role,
                Email = createdUser.Email,
                Phone = createdUser.Phone,
                LastUpdated = createdUser.LastUpdated
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserViewModel model)
        {
            var dto = new UserDTO { Name = model.Name, Role = model.Role, Email = model.Email, Phone = model.Phone, LastUpdated = model.LastUpdated };
            var updated = await _userService.UpdateUserAsync(id, dto);

            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);
            if (user == null || !VerifyPassword(model.Password, user.Password))
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(new { message = "Login successful", userId = user.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}