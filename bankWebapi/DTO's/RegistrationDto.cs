namespace bank_App.DTOs
{
    public class RegistrationDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; } // Date of Birth as string
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string IdNumber { get; set; }
        public string passport { get; set; } // lowercase 'passport'
        public string Customer_ID { get; set; }
    }
}
