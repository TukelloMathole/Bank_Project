using bank_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;

    public AccountService(AppDbContext context)
    {
        _context = context;
    }

    public string GenerateAccountNumber()
    {
        // Simulate getting the last account number from database
        var lastAccount = _context.Account_Table
                                   .OrderByDescending(a => a.Account_Number)
                                   .FirstOrDefault();

        // Assuming you have the bank and branch identifiers
        string bankIdentifier = "1234"; // Replace with actual bank identifier
        string branchIdentifier = "5678"; // Replace with actual branch identifier

        // Initialize the counter for the last 4 digits
        int last4Digits = 0;

        if (lastAccount != null)
        {
            // Extract the last 4 digits from the existing account number and increment
            string lastAccountNumber = lastAccount.Account_Number.Substring(8, 4); // Assuming account number format is "123456789012345"
            last4Digits = int.Parse(lastAccountNumber) + 1;
        }

        // Format the account number
        string accountNumber = $"{bankIdentifier}{branchIdentifier}{last4Digits.ToString("0000")}";

        return accountNumber;
    }
    public DateTime GenerateExpiryDate()
    {
        // Determine the validity period (in years) for the card
        int validityPeriodInYears = 5; // Example: Set validity period to 3 years

        // Calculate the expiry date based on the current date
        DateTime currentDate = DateTime.UtcNow;
        DateTime expiryDate = currentDate.AddYears(validityPeriodInYears);

        // Return the calculated expiry date
        return expiryDate;
    }
    public string GenerateCVV(string Account_Number, DateTime Expiry_Date)
    {
        // Convert expiry date to string in MMYY format
        string expiryDateString = Expiry_Date.ToString("MMyy");

        // Concatenate the account number and expiry date
        string dataToHash = Account_Number + expiryDateString;

        // Use a secret key for HMAC hashing (in a real application, this key should be securely stored)
        string secretKey = "yourSecretKey"; // Replace with your actual secret key

        // Use HMACSHA256 to generate the hash
        using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));

            // Convert the hash to a string of digits and take the first 3 or 4 digits as the CVV
            StringBuilder hashString = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashString.Append(b.ToString("X2"));
            }

            // Example: taking the first 3 digits for CVV
            string cvv = hashString.ToString().Substring(0, 3);

            return cvv;
        }
    }
    public decimal GenerateDefaultBalance()
    {
        // Implement your default balance generation logic
        return 0.0m; // Example: starting balance is zero
    }
    public string GenerateDefaultStatus()
    {
        // Implement your default status generation logic
        return "Inactive"; // Example: account is active by default
    }
}
