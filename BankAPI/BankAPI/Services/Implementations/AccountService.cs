using BankAPI.DAL;
using BankAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly youBankingDbContext _dbContext;

        public AccountService(youBankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> AuthenticateAsync(string AccountNumber, string Pin)
        {
            var account = _dbContext.Accounts.SingleOrDefault(x => x.AccountNumberGenerated == AccountNumber);
            if (account == null)
                return null;

            if (!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
                return null;

            return account;
        }

        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if (string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException("Pin");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Pin));
                for (int i = 0; i < computedPinHash.Length; i++)
                {
                    if (computedPinHash[i] != pinHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Account> CreateAsync(Account account, string Pin, string ConfirmPin)
        {
            if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("An account already exists with this email");

            if (!Pin.Equals(ConfirmPin)) throw new ArgumentException("Pins do not match", "Pin");

            byte[] pinHash, pinSalt;
            CreatePinHash(Pin, out pinHash, out pinSalt);

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();

            return account;
        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public async Task Delete(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await Task.FromResult(_dbContext.Accounts.ToList());
        }

        public async Task UpdateAsync(Account account, string Pin = null)
        {
            var accountToBeUpdated = _dbContext.Accounts.SingleOrDefault(x => x.Email == account.Email);
            if (accountToBeUpdated == null) throw new ApplicationException("Account does not exist");

            if (!string.IsNullOrWhiteSpace(account.Email))
            {
                if (_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException("This email " + account.Email + " already exists");

                accountToBeUpdated.Email = account.Email;
            }

            if (!string.IsNullOrWhiteSpace(account.PhoneNumber))
            {
                if (_dbContext.Accounts.Any(x => x.PhoneNumber == account.PhoneNumber)) throw new ApplicationException("This phone number " + account.PhoneNumber + " already exists");

                accountToBeUpdated.PhoneNumber = account.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(Pin))
            {
                byte[] pinHash, pinSalt;

                CreatePinHash(Pin, out pinHash, out pinSalt);

                accountToBeUpdated.PinHash = pinHash;
                accountToBeUpdated.PinSalt = pinSalt;
            }
            accountToBeUpdated.DateLastUpdated = DateTime.Now;
            _dbContext.Accounts.Update(accountToBeUpdated);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            var account = await _dbContext.Accounts.Where(x => x.AccountId == id).FirstOrDefaultAsync();
            if (account == null)
                return null;
            return account;
        }

        public async Task<Account> GetByNumberAsync(string AccountNumber)
        {
            var account = await _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefaultAsync();
            if (account == null) return null;

            return account;

        }


        void IAccountService.Delete(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges();
            }
        }
    }

}

