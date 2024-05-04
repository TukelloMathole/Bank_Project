using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CustomerIdGenerator
{
    private readonly AppDbContext _dbContext;

    public CustomerIdGenerator(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string GenerateCustomerId()
    {
        string lastAccountId = _dbContext.AccountInfos
    .OrderByDescending(a => a.ID)
    .Select(a => a.IDNumber)
    .FirstOrDefault();

        int lastNumber = 0;
        if (!string.IsNullOrEmpty(lastCustomerId) && lastCustomerId.StartsWith("CUST") && int.TryParse(lastCustomerId.Substring(4), out lastNumber))
        {
            lastNumber++; // Increment the last number
        }
        else
        {
            lastNumber = 1; // If no previous customer ID found, start from 1
        }

        return "CUST" + lastNumber.ToString("D3");
    }

    public string GenerateAccountNumber()
    {
        // Logic to generate account number
        // You can customize this logic as per your requirements
        Random random = new Random();
        return "ACC" + random.Next(100000, 999999).ToString();
    }
}
