using BACKEND_Assignment.Data;
using BACKEND_Assignment.DTO;
using BACKEND_Assignment.Models;
using BACKEND_Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_Assignment.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController :ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public UserController(ApplicationDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUserByUsername = await _context.User.FirstOrDefaultAsync(u => u.UserName == userDto.UserName);
            if (existingUserByUsername != null)
                return BadRequest("Username already exists");

            var existingUserByMobileNumber = await _context.User.FirstOrDefaultAsync(u => u.MobileNumber == userDto.MobileNumber);
            if (existingUserByMobileNumber != null)
                return BadRequest("Account with this mobile number already exists");

            var user = new User
            {
                UserName = userDto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Role = "User",
                MobileNumber = userDto.MobileNumber
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.User.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                return Unauthorized("Invalid username or password");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }





    }
}
