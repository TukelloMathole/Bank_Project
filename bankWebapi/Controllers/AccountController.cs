using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using bank_App.Model;
using System;

[Route("api/[controller]")]
[ApiController]
 // Requires authentication for all actions in this controller
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }
    [Authorize]
    // POST: api/account/details
    [HttpPost("details")]
    public async Task<ActionResult<string>> GetAccountDetails([FromBody] TokenRequestDto dto)
    {
        if (!Request.Headers.ContainsKey("authorization"))return Unauthorized();
        try
        {
            if (string.IsNullOrWhiteSpace(dto.token))
            {
                return BadRequest("Token is required."); // Return 400 Bad Request if token is missing
            }

            // Log the token received from the request body
            Console.WriteLine($"Token received: {dto.token}");

            // Return a "Hello back" message
            return Ok("Hello back");
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}
