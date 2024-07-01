using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/account/details/{customerId}
    [HttpGet("details/{customerId}")]
    public async Task<ActionResult<AccountDetailsDto>> GetAccountDetails(string customerId)
    {
        var account = await _context.Account_Table
            .FirstOrDefaultAsync(a => a.Customer_ID == customerId);

        if (account == null)
        {
            return NotFound(); // Return 404 if user's account is not found
        }

        // Map the account entity to a DTO (Data Transfer Object) to serve specific details
        var accountDetails = new AccountDetailsDto
        {
            AccountNumber = account.Account_Number,
            AccountType = account.Card_Type,

            Balance = account.Balance
            // Add other properties as needed
        };

        return Ok(accountDetails);
    }
}
