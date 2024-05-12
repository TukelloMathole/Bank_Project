using Microsoft.AspNetCore.Mvc;
using System;
using bank_App.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using bank_App.Model;

[ApiController]
[Route("[controller]")]
public class BankAccountRegistrationController : ControllerBase
{
    private readonly AppDbContext _context;
    private static readonly Random random = new Random();

    public BankAccountRegistrationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterPersonalInfo(UserPersonalInformation personalInfo)
    {
        if (personalInfo == null)
        {
            return BadRequest("Invalid data provided.");
        }
        string customerID = AccountGenerator.GenerateCustomerID();
        //string accountNumber = AccountGenerator.GenerateAccountNumber(personalInfo.Account_Type);

        // Remove the assignment of ID property
        personalInfo.ID = 0;

        // Assign generated IDs to the personalInfo object
        personalInfo.Customer_ID = customerID;
        //personalInfo.AccountNumber = accountNumber;

        try
        {
            // Add the personalInfo object to the database
            _context.UserPersonalInformation.Add(personalInfo);
            await _context.SaveChangesAsync();

            return Ok("Personal information registered successfully. Customer ID: " + customerID + ", Account Number: " );
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while registering personal information: {ex.Message}");
        }
    }
}
