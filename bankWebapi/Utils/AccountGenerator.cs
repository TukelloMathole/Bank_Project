using System;
using System.Linq;
using bank_App.Model;
using Microsoft.EntityFrameworkCore; // Import Entity Framework Core for DbContext

namespace bank_App.Utils
{
    public static class AccountGenerator
    {
        // Generate customer ID based on the last customer ID in the database
        public static string GenerateCustomerID()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var lastCustomer = context.UserPersonalInformation
                        .OrderByDescending(b => b.Customer_ID)
                        .FirstOrDefault();

                    int lastCustomerNumber = 0;
                    int length = 0;

                    if (lastCustomer != null && !string.IsNullOrEmpty(lastCustomer.Customer_ID) &&
                        int.TryParse(lastCustomer.Customer_ID.Replace("CUST", ""), out lastCustomerNumber))
                    {
                        lastCustomerNumber++;
                        length = lastCustomer.Customer_ID.Length - "CUST".Length;
                    }
                    else
                    {
                        lastCustomerNumber = 1;
                        length = 1;
                    }

                    string nextCustomerID = "CUST" + lastCustomerNumber.ToString("D" + length);
                    return nextCustomerID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the customer ID: " + ex.Message);
                throw;
            }
        }

        // Generate account number in ascending order based on the last generated number from the database
        public static string GenerateAccountNumber(string type)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var lastAccount = context.Accounts
                        .Where(a => a.Account_Type == type)
                        .OrderByDescending(a => a.Account_Number)
                        .FirstOrDefault();

                    int lastAccountNumber = 0;
                    if (lastAccount != null && !string.IsNullOrEmpty(lastAccount.Account_Number) &&
                        int.TryParse(lastAccount.Account_Number, out lastAccountNumber))
                    {
                        lastAccountNumber++;
                    }
                    else
                    {
                        lastAccountNumber = 1;
                    }

                    return lastAccountNumber.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the account number: " + ex.Message);
                throw;
            }
        }
    }
}
