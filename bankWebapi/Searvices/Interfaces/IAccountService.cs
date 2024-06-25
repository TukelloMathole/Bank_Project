using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;

public interface IAccountService
{
    string GenerateAccountNumber();
    DateTime GenerateExpiryDate();
    string GenerateCVV(string Account_Number, DateTime Expiry_Date);
    string GenerateDefaultStatus();
    decimal GenerateDefaultBalance();
}
