using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BankAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Account Authenticate(string AccountNumber, string Pin);

        IEnumerable<Account> GetAllAccounts();

        Account Create(Account account, string Pin, string ConfirmPin);

        void Update(Account account, string pin = null);

        void Delete(int id);

        Account GetById(int id);

        Account GetByNumber(string AccountNumber);
    }
}
