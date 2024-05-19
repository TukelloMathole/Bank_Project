namespace bank_App.Model
{
    public class BankRegistration
    {
        public UserPersonalInformation UserPersonalInformation { get; set; }
        public UserContactInformation ContactInformation { get; set; }
        public string EmploymentStatus { get; set; }
        public string Card_Type { get; set; }
        public int IncomeDetails { get; set; }
        public int TaxNumber { get; set; }
        public int BankDetails { get; set; } 
        public int Pin { get; set; }
        public SecurityAuthentication Authentication { get; set; }
    }
}
