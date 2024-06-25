namespace bank_App.Model
{
    public class FinancialInformation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal IncomeDetails { get; set; }
        public string EmploymentStatus { get; set; }
        public string FinancialInstitutionDetails {  get; set; }
        public string TaxIdNumber { get; set; }
    }
}
