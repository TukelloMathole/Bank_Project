using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace bank_App.Model
{
    public class UserPersonalInformation
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string IDNumber { get; set; }
        public string Passport { get; set; }
        public string Customer_ID { get; set; } // Assuming it's spelled as "Customer_ID" in the database
    }
}


// Console the dictionary



