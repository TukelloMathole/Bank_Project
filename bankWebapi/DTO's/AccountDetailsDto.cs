public class AccountDetailsDto
{
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    // Add other properties as needed
    public DateTime ExpiryDate { get; set; }
    public string CVV { get; set; }
    public string Status { get; set; }
    public string Pin { get; set; }
    // personal information
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}