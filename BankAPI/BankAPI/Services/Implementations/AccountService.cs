using BankAPI.DAL;
using BankAPI.Services.Interfaces;
using Microsoft.Identity.Client;
using System.Text;

namespace BankAPI.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private youBankingDbContext _dbContext;

        public AccountService(youBankingDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        async Task<Account> IAccountService.AuthenticateAsync(string AccountNumber, string Pin)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).SingleOrDefault();
            if (account == null)
                return null;

            if (!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
                return null;

            return account;
        }
        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin");

            using (var hmac =  new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));
                for(int i = 0; i < computedPinHash.Length; i++)
                {
                    if (computedPinHash[i] != pinHash[i]) return false;
                }
            }
            return true;
        }

        async Task<Account> IAccountService.CreateAsync(Account account, string Pin, string ConfirmPin)
        {
            if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("An account allready exists with this email");

            if (!Pin.Equals(ConfirmPin)) throw new ArgumentException("Pins do not match", "Pin");

            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash,out pinSalt);

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return account;



        }
        private static void CreatePinHash(string pin , out byte[] pinHash, out byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }

        }

        void IAccountService.Delete(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            if(account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges();
            }
        }

        async Task<IEnumerable<Account>> IAccountService.GetAllAccountsAsync()
        {
            return  _dbContext.Accounts.ToList();
        }

        async Task IAccountService.UpdateAsync(Account account, string Pin = null)
        {
            var accountToBeUpdated = _dbContext.Accounts.Where(x => x.Email == account.Email).SingleOrDefault();
            if (accountToBeUpdated == null) throw new ApplicationException("Account does not exist");

            if(string.IsNullOrWhiteSpace(account.Email))
            {
                if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("This email " + account.Email + " already exists");
                
                accountToBeUpdated.Email = account.Email;

            
            }
            if (string.IsNullOrWhiteSpace(account.PhoneNumber))
            {
                if (_dbContext.Accounts.Any(x => x.PhoneNumber == account.PhoneNumber)) throw new ApplicationException("This phone number " + account.PhoneNumber + " already exists");

                accountToBeUpdated.PhoneNumber = account.PhoneNumber;



            }
            if (string.IsNullOrWhiteSpace(Pin))
            {
                byte[] pinHash, pinSalt;

                CreatePinHash(Pin, out pinHash, out pinSalt);

                accountToBeUpdated.PinHash = pinHash;
                accountToBeUpdated.PinSalt = pinSalt;
               
            }
            accountToBeUpdated.DateLastUpdated = DateTime.Now;
            _dbContext.Accounts.Update(accountToBeUpdated);
            _dbContext.SaveChanges();
        }

        async Task<Account> IAccountService.GetByIdAsync(int id)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountId == id).FirstOrDefault();
            if (account == null)
                return null;
            return account;
        }

        async Task<Account> IAccountService.GetByNumberAsync(string AccountNumber)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefault();
            if (account == null) return null;

            return account;

        }
    }
}
