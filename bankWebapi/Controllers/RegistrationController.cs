using Microsoft.AspNetCore.Mvc;
using bank_App.Model;
using bank_App.DTOs;
using System;
using Microsoft.EntityFrameworkCore;

namespace bank_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICustomerIdService _customerIdService;
        private readonly IAccountService _accountService;

        public UserController(AppDbContext context, ICustomerIdService customerIdService, IAccountService accountService)
        {
            _context = context;
            _customerIdService = customerIdService;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerId = _customerIdService.GenerateCustomerId();
            var accountNumber = _accountService.GenerateAccountNumber();
            var expiryDate = _accountService.GenerateExpiryDate();

            var user = new UserPersonalInformation
            {
                FirstName = registrationDto.FirstName,
                MiddleName = registrationDto.MiddleName,
                LastName = registrationDto.LastName,
                DateOfBirth = DateTime.Parse(registrationDto.Dob), // Convert string to DateTime
                Gender = registrationDto.Gender,
                Nationality = registrationDto.Nationality,
                IdNumber = registrationDto.IdNumber,
                Passport = registrationDto.passport, // Use lowercase property name
                Customer_ID = customerId,
            };

            try
            {
                // Save UserPersonalInformation first to get the ID
                _context.UserPersonalInformation.Add(user);
                _context.SaveChanges();

                var userContactInfo = new UserContactInformation
                {
                    Customer_ID = customerId,
                    Country = registrationDto.Country,
                    Province = registrationDto.Province,
                    City = registrationDto.City,
                    Suburb = registrationDto.Suburb,
                    Street = registrationDto.Street,
                    PostalCode = registrationDto.PostalCode,
                    HouseNumber = registrationDto.HouseNumber,
                    Email = registrationDto.Email,
                    PhoneNumber = registrationDto.PhoneNumber,
                };

                var userAccountInfo = new Account_Table
                {
                    Customer_ID = customerId,
                    Account_Number = accountNumber,
                    Expiry_Date = expiryDate,
                    CVV = _accountService.GenerateCVV(accountNumber, expiryDate),
                    Card_Type = registrationDto.accountType,
                    Status = _accountService.GenerateDefaultStatus(),
                    Pin = registrationDto.pin,
                    Balance = _accountService.GenerateDefaultBalance(),
                };

                var userSecurityAuth = new SecurityAuthentication
                {
                    Customer_ID = customerId,
                    Username = registrationDto.Username,
                    Password = registrationDto.Password,
                    Role = "User"
                };

                var userFinancialDetail = new FinancialInformation
                {
                    UserID = user.ID, // Use the newly created user ID
                    IncomeDetails = registrationDto.incomeDetails,
                    EmploymentStatus = registrationDto.employmentStatus,
                    FinancialInstitutionDetails = registrationDto.financialInstitutionDetails,
                    TaxIdNumber = registrationDto.taxIdNumber
                };

                // Save other related information
                _context.UserContactInformation.Add(userContactInfo);
                _context.SaveChanges();

                _context.Account_Table.Add(userAccountInfo);
                _context.SaveChanges();

                _context.SecurityAuthentication.Add(userSecurityAuth);
                _context.SaveChanges();

                _context.FinancialInformation.Add(userFinancialDetail);
                _context.SaveChanges();

                return Ok(new
                {
                    UserId = user.ID,
                    user.FirstName,
                    user.MiddleName,
                    user.LastName,
                    user.DateOfBirth,
                    user.Gender,
                    user.Nationality,
                    user.IdNumber,
                    user.Passport,
                    user.Customer_ID,
                    userContactInfo.Country,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
