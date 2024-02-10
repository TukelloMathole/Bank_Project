using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    private readonly string _connectionString;

    public HelloController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            // Create a list to hold the results
            List<string> results = new List<string>();

            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Open the connection
                connection.Open();

                // Perform some database operations (e.g., executing a query)
                string query = "SELECT * FROM BankAccountRegistration";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read data from the reader
                        while (reader.Read())
                        {
                            // Access data from the reader
                            int id = reader.GetInt32(0); // Assuming the first column is of type INT
                            string firstName = reader.GetString(1); // Assuming the second column is of type VARCHAR
                            string lastName = reader.GetString(2); // Assuming the third column is of type VARCHAR

                            // Do something with the data, such as adding it to the results list
                            results.Add($"ID: {id}, First Name: {firstName}, Last Name: {lastName}");
                        }
                    }
                }
            }

            // Return the results as JSON
            return Ok(results);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
