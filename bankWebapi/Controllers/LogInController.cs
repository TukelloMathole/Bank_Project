using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using bank_App.DTOs; // Include the namespace where LoginDto is defined
using bank_App.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace bank_App.Controllers
{
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LogInController> _logger;

        public LogInController(AppDbContext context, IConfiguration configuration, ILogger<LogInController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // POST: /api/login
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.SecurityAuthentication
                .SingleOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (user == null)
            {
                _logger.LogWarning("Invalid login attempt for user: {Username}", loginDto.Username);
                return BadRequest("Invalid username or password");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token, Role = user.Role });
        }

        private string GenerateJwtToken(SecurityAuthentication user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Customer_ID", user.Customer_ID)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
