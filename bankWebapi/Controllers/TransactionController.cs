using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using bank_App.Model; // Replace with your namespace and model

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context; // Replace AppDbContext with your actual DbContext

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/transactions
    [HttpPost]
    public ActionResult<IEnumerable<TransactionDto>> GetTransactions(TransactionRequestDto requestDto)
    {
        try
        {
            if (requestDto == null || string.IsNullOrWhiteSpace(requestDto.Customer_ID))
            {
                return BadRequest("Customer_ID is required.");
            }

            // Retrieve transactions for the given Customer_ID
            var transactions = _context.TransactionTable
                                .Where(a => a.Customer_ID == requestDto.Customer_ID)
                                .Select(a => new TransactionDto
                                {
                                    Transaction_ID = a.Transaction_ID,
                                    Account_Number = a.Account_Number,
                                    Transaction_Type = a.Transaction_Type,
                                    Amount = a.Amount,
                                    Transaction_Date = a.Transaction_Date,
                                    Customer_ID = a.Customer_ID
                                })
                                .ToList();

            return Ok(transactions);
        }
        catch (Exception ex)
        {
            // Log the exception for troubleshooting
            // logger.LogError(ex, "Error retrieving transactions");
            return StatusCode(500, ex);
        }
    }
}
