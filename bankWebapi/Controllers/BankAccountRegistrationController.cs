using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

[ApiController]
[Route("[controller]")]
public class BankAccountRegistrationController : ControllerBase
{
    private readonly string _connectionString;

    public BankAccountRegistrationController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpPost]
    public IActionResult Create(BankAccountRegistrationModel model)
    {
        try
        {
            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Open the connection
                connection.Open();

                // Insert the data into the database
                string query = @"INSERT INTO BankAccountRegistration 
                                (firstName, lastName, dateOfBirth, country, province, city, surbab, street, postalCode, email, phoneNumber, idNumber)
                                VALUES 
                                (@FirstName, @LastName, @DateOfBirth, @Country, @Province, @City, @Surbab, @Street, @PostalCode, @Email, @PhoneNumber, @IdNumber)";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    command.Parameters.AddWithValue("@Province", model.Province);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Surbab", model.Surbab);
                    command.Parameters.AddWithValue("@Street", model.Street);
                    command.Parameters.AddWithValue("@PostalCode", model.PostalCode);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@IdNumber", model.IdNumber);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return Ok("Registration successful.");
                    }
                    else
                    {
                        return BadRequest("Registration failed.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
