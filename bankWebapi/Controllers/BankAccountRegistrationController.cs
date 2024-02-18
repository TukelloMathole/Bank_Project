using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class BankAccountRegistrationController : ControllerBase
{
    private readonly string _connectionString;
    private readonly BankAccountRegistrationModel _registrationModel;

    public BankAccountRegistrationController(IConfiguration configuration, BankAccountRegistrationModel registrationModel)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _registrationModel = registrationModel;
    }

    [HttpPost]
    public IActionResult Create(BankAccountRegistrationModel model)
    {
        try
        {
            if (model == null || model.Data == null || model.Data.Count == 0)
            {
                return BadRequest("No data provided.");
            }

            // Generate Customer_ID
            string customerId = model.GenerateCustomerID();

            // Add Customer_ID to each table's data
            foreach (var tableData in model.Data.Values)
            {
                tableData["Customer_ID"] = customerId;
            }

            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var kvp in model.Data)
                {
                    string query = "";
                    switch (kvp.Key)
                    {
                        case "BankAccountRegistration":
                            query = @"INSERT INTO BankAccountRegistration 
                                (FirstName, LastName, DateOfBirth, IDNumber, Country, Province, City, Surbub, Street, PostalCode, HouseNumber, Email, PhoneNumber, Customer_ID)
                                VALUES 
                                (@FirstName, @LastName, @DateOfBirth, @IDNumber, @Country, @Province, @City, @Surbub, @Street, @PostalCode, @HouseNumber, @Email, @PhoneNumber, @Customer_ID)";
                            break;
                        case "AccountInfo":
                            // Generate Account_Number
                            kvp.Value["Account_Number"] = model.GenerateAccountNumber();

                            query = @"INSERT INTO AccountInfo 
                                (Customer_ID, Account_Number, Pin_Number, Account_Type, Balance, Account_Status)
                                VALUES 
                                (@Customer_ID, @Account_Number, @Pin_Number, @Account_Type, @Balance, @Account_Status)";
                            break;
                        case "SecurityAuthentication":
                            query = @"INSERT INTO SecurityAuthentication 
                                (Username, Password, Role, Customer_ID)
                                VALUES 
                                (@Username, @Password, @Role, @Customer_ID)";
                            break;
                        default:
                            return BadRequest("Unknown table name.");
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var pair in kvp.Value)
                        {
                            command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            return BadRequest($"{kvp.Key} creation failed.");
                        }
                    }
                }

                return Ok("Registration and account setup successful.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
