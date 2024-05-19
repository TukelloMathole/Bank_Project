using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using bank_App.Model;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class BankAccountRegistrationController : ControllerBase
{
    private readonly AppDbContext _context;

    public BankAccountRegistrationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterPersonalInfo(BankRegistration BankRegistration)
    {
        if (BankRegistration == null)
        {
            return BadRequest("Invalid data provided.");
        }

        try
        {
            // Create UserContactInformation entity
           /* var userContact = new UserContactInformation
            {
                // Populate properties from personalInfo
                // Note: You may need to adjust property mappings based on your actual model
                Country = personalInfo.Country,
                Province = personalInfo.Province,
                City = personalInfo.City,
                Suburb = personalInfo.Suburb,
                Street = personalInfo.Street,
                PostalCode = personalInfo.PostalCode,
                HouseNumber = personalInfo.HouseNumber,
                Email = personalInfo.Email,
                PhoneNumber = personalInfo.PhoneNumber
            };*/

            // Add userContact to the context
            //_context.UserContactInformation.Add(userContact);
            await _context.SaveChangesAsync();

            // Create SecurityAuthentication entity
           /* var securityAuthentication = new SecurityAuthentication
            {
                // Populate properties from personalInfo
                // Note: You may need to adjust property mappings based on your actual model
                Password = BankRegistration.Password,
                Role = BankRegistration.Role
            };*/

            // Add securityAuthentication to the context
            /*_context.SecurityAuthentication.Add(securityAuthentication);
            await _context.SaveChangesAsync();

            // Populate other properties and save personalInfo to UserPersonalInformation table
            // personalInfo.userContact = userContact; // Associate userContact with personalInfo
            BankRegistration.Authentication = securityAuthentication; // Associate securityAuthentication with personalInfo
            _context.UserPersonalInformation.Add(BankRegistration);
            await _context.SaveChangesAsync();*/

            return Ok("Personal information registered successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while registering personal information: {ex}");
        }
    }
}
