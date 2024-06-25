using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace bank_App.Model
{
    public class UserContactInformation
    {
        public string Customer_ID { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
