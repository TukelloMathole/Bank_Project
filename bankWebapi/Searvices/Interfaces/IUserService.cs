using bank_App.Model;

public interface IUserService
{
    UserPersonalInformation CreateUser(BankRegistration BankRegistration);
    string GenerateAccountNumber(string type);
    string GenerateCustomerID();
}
