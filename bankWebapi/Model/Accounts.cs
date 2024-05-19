using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace bank_App.Model
{
    public class Account_Table
    {
        public int Account_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Account_Number { get; set; }
        public DateTime Expiry_Date { get; set; }
        public int CVV { get; set; }
        public string Card_Type { get; set; }
        public string Status { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
    }
}
