using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using bank_App.DTOs; // Include the namespace where LoginDto is defined

namespace bank_App.Controllers
{
    [ApiController]
    public class LogInController : ControllerBase
    {
        // Dummy user data (replace with your actual data source)
        private List<User> users = new List<User>
        {
            new User { Username = "admin", Password = "adminpassword", Role = "admin" },
            new User { Username = "user", Password = "userpassword", Role = "user" }
        };

        // POST: /api/login
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // Find user based on username and password
            var user = users.SingleOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            // Simulate token generation (replace with actual token generation logic)
            var token = "dummy_token";

            // Return token and user role
            return Ok(new { Token = token, Role = user.Role });
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
