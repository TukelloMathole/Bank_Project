using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace bank_App.Model
{
    public class Accounts
    {
        public int Account_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Account_Number { get; set; }
        public string Pin_Number { get; set; }
        public string Account_Type { get; set; }
        public decimal Balance { get; set; }
        public string Account_Status { get; set; }
    }
}
