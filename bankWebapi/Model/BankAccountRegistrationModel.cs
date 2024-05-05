using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class BankAccountRegistrationModel
{
    public class BankAccountRegistration
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; } // Assuming it's stored as a string in the database
        public string IDNumber { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Surbub { get; set; } // Assuming it's spelled as "Surbub" in the database
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public string Account_Type { get; set; }
        public string Customer_ID { get; set; } // Assuming it's spelled as "Customer_ID" in the database
    }

}

// Console the dictionary
