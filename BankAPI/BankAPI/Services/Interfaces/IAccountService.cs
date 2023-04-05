using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BankAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> AuthenticateAsync(string AccountNumber, string Pin);

        Task<IEnumerable<Account>> GetAllAccountsAsync();

        Task<Account> CreateAsync(Account account, string Pin, string ConfirmPin);

        Task UpdateAsync(Account account, string pin = null);

        void Delete(int id);

        Task<Account> GetByIdAsync(int id);

        Task<Account> GetByNumberAsync(string AccountNumber);
    }
}
