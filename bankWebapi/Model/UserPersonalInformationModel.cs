using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;


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
        //public string Customer_ID { get; set; }

        /*public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }*/
        

        /*public string EmploymentStatus { get; set; }
        public string Card_Type { get; set; }
        public int IncomeDetails { get; set; }
        public int TaxNumber { get; set; }
        public int BankDetails { get; set; }
        public int Pin { get; set; }*/
        
        /*public string Password { get; set; }
        public string Role { get; set; }*/
        
    }
}


