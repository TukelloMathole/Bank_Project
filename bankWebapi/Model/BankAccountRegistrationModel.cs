using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class BankAccountRegistrationModel
{
    private readonly string _connectionString;

    public BankAccountRegistrationModel(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Dictionary<string, Dictionary<string, string>>? Data { get; set; }

    public string GenerateCustomerID()
{
    // Initialize the customer ID prefix
    string customerIdPrefix = "CUS";

    // Initialize the customer ID number
    int customerIdNumber = 1;

    // Connect to the database and retrieve the maximum existing Customer_ID
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        // Query to retrieve the maximum existing Customer_ID
        string query = "SELECT MAX(Customer_ID) AS MaxCustomerId FROM BankAccountRegistration";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            // Execute the query and retrieve the maximum Customer_ID
            object? result = command.ExecuteScalar();
            string? maxCustomerId = result?.ToString(); // Use null-conditional operator

            if (!string.IsNullOrEmpty(maxCustomerId))
            {
                // Extract the numeric part of the maximum Customer_ID
                int startIndex = customerIdPrefix.Length;
                string numericPart = maxCustomerId.Substring(startIndex) ?? ""; // Use null-coalescing operator

                // Parse the numeric part to get the maximum customer ID number
                if (int.TryParse(numericPart, out int maxCustomerIdNumber))
                {
                    customerIdNumber = maxCustomerIdNumber + 1;
                }
            }
        }
    }

    // Format the new Customer_ID
    return $"{customerIdPrefix}{customerIdNumber:D3}";
}


    public string GenerateAccountNumber()
    {
        // Initialize the account number prefix
        string accountNumberPrefix = "A";

        // Initialize the account number
        string accountNumber = "";

        // Connect to the database and generate a unique 12-digit account number
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            // Repeat until a unique account number is generated
            while (true)
            {
                // Generate a random 9-digit number
                string randomDigits = GenerateRandomDigits(9);

                // Concatenate the prefix with the random digits to form the account number
                accountNumber = $"{accountNumberPrefix}{randomDigits}";

                // Query to check if the generated account number already exists in the database
                string query = "SELECT COUNT(*) FROM AccountInfo WHERE Account_Number = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    int count = (int)command.ExecuteScalar();

                    // If the count is zero, it means the account number is unique, so break out of the loop
                    if (count == 0)
                    {
                        break;
                    }
                }
            }
        }

        return accountNumber;
    }

    // Helper method to generate random digits
    private string GenerateRandomDigits(int length)
    {
        Random random = new Random();
        string digits = "";
        for (int i = 0; i < length; i++)
        {
            digits += random.Next(10).ToString();
        }
        return digits;
    }
}
