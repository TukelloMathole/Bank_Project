using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using bank_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

    // POST: api/account/details
    [HttpPost("details")]
    [Authorize]
    public async Task<ActionResult<List<AccountDetailsDto>>> GetAccountDetails([FromBody] AccountDetailsRequest dto)
    {
        if (!Request.Headers.ContainsKey("authorization")) return Unauthorized();

        try
        {
            if (string.IsNullOrWhiteSpace(dto.Customer_ID))
            {
                return BadRequest("Customer ID is required."); // Return 400 Bad Request if Customer ID is missing
            }

            // Log the Customer ID received from the request body
            Console.WriteLine($"Customer ID received: {dto.Customer_ID}");

            // Fetch account details including personal information
            var accountDetails = await _context.Account_Table
                .Where(a => a.Customer_ID == dto.Customer_ID)
                .Join(_context.UserPersonalInformation,
                      a => a.Customer_ID,
                      u => u.Customer_ID,
                      (a, u) => new AccountDetailsDto
                      {
                          AccountNumber = a.Account_Number,
                          AccountType = a.Card_Type,
                          Balance = a.Balance,
                          ExpiryDate = a.Expiry_Date,
                          CVV = a.CVV,
                          Status = a.Status,
                          Pin = a.Pin,
                          FirstName = u.FirstName,
                          MiddleName = u.MiddleName,
                          LastName = u.LastName
                          // Map other properties as needed
                      })
                .ToListAsync();

            if (accountDetails == null || accountDetails.Count == 0)
            {
                return NotFound("No account details found for the given Customer ID.");
            }

            return Ok(accountDetails);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}