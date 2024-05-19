using System;
using System.Linq;
using bank_App.Model;
using Microsoft.EntityFrameworkCore;

namespace bank_App.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public UserPersonalInformation CreateUser(BankRegistration BankRegistration)
        {
            var Customer_ID = GenerateCustomerID();
            var AccountNumber = GenerateAccountNumber(BankRegistration.Card_Type); 
            // Save user information to the database
            _context.UserPersonalInformation.Add(BankRegistration);
            _context.SaveChanges();
            return BankRegistration;
        }

        public string GenerateAccountNumber(string type)
        {
            try
            {
                var lastAccount = _context.Account_Table
                    .Where(a => a.Card_Type == type)
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the account number: " + ex.Message);
                throw;
            }
        }

        public string GenerateCustomerID()
        {
            try
            {
                var nextCustomerID = "cus100";
                /*var lastCustomer = _context.UserPersonalInformation
                    .OrderByDescending(b => b.Customer_ID)
                    .FirstOrDefault();

                int lastCustomerNumber = 0;
                int length = 4; // Default length

                if (lastCustomer != null && !string.IsNullOrEmpty(lastCustomer.Customer_ID) &&
                    int.TryParse(lastCustomer.Customer_ID.Replace("CUST", ""), out lastCustomerNumber))
                {
                    lastCustomerNumber++;
                }
                else
                {
                    lastCustomerNumber = 1;
                }

                string nextCustomerID = "CUST" + lastCustomerNumber.ToString("D" + length);*/
                return nextCustomerID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the customer ID: " + ex.Message);
                throw;
            }
        }
    }
}
