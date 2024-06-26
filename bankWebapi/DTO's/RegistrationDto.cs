namespace bank_App.DTOs
{
    public class RegistrationDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; } 
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string IdNumber { get; set; }
        public string passport { get; set; } 

        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string accountType { get; set; }
        public string pin { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string employmentStatus { get; set; }
        public string financialInstitutionDetails { get; set; }
        public string taxIdNumber { get; set; }
        public decimal incomeDetails { get; set; }
    }
}
