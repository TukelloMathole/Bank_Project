using bank_App.Model;
using System.Linq;

public class CustomerIdService : ICustomerIdService
{
    private readonly AppDbContext _context;

    public CustomerIdService(AppDbContext context)
    {
        _context = context;
    }

    public string GenerateCustomerId()
    {
        string lastCustomerId = GetLastCustomerId();
        int lastNumber = ExtractNumberFromCustomerId(lastCustomerId);

        // Generate new Customer_ID based on the last number
        string newCustomerId = "CUS" + (lastNumber + 1).ToString("D4"); // Example: CUS1235

        return newCustomerId;
    }

    public string GetLastCustomerId()
    {
        var lastCustomer = _context.UserPersonalInformation
            .OrderByDescending(u => u.ID)
            .FirstOrDefault();

        if (lastCustomer != null)
        {
            return lastCustomer.Customer_ID;
        }

        // Return a default value if no customer exists yet
        return "CUS0000"; // Example: Starting ID if no users exist
    }

    // Helper method to extract number from Customer_ID
    private int ExtractNumberFromCustomerId(string customerId)
    {
        if (customerId != null && customerId.StartsWith("CUS") && customerId.Length == 7)
        {
            if (int.TryParse(customerId.Substring(3), out int number))
            {
                return number;
            }
        }
        // Default to 1000 if parsing fails
        return 1000;
    }
}