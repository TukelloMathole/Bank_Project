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

        public UserController(AppDbContext context, ICustomerIdService customerIdService)
        {
            _context = context;
            _customerIdService = customerIdService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegistrationDto registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerId = _customerIdService.GenerateCustomerId();
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

            try
            {
                _context.UserPersonalInformation.Add(user);
                _context.SaveChanges();

                _context.UserContactInformation.Add(userContactInfo);
                _context.SaveChanges();
                // Return user details upon successful registration
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
