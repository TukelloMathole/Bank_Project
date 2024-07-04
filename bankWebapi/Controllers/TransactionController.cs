using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<List<TransactionDto>>> GetTransactionsByCustomerId([FromBody] TransactionRequestDto request)
    {
        if (string.IsNullOrEmpty(request.Customer_ID))
        {
            return BadRequest("Customer_ID is required.");
        }

        var transactions = await _context.TransactionTable
            .Where(t => t.Customer_ID == request.Customer_ID)
            .Select(t => new TransactionDto
            {
                Transaction_ID = t.Transaction_ID,
                Account_Number = t.Account_Number,
                Transaction_Type = t.Transaction_Type,
                Amount = t.Amount,
                Transaction_Date = t.Transaction_Date,
                Balance = t.Balance,
            })
            .ToListAsync();

        return Ok(transactions);
    }
}
