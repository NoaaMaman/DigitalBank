using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankproject.Common.Dtos;

namespace Bankproject.Common.Interfaces
{
    public interface IAccount
    {
        Task<int> CreateAccountAsync(AccountCreate adressCreate);

        Task UpdateAccountAsync(AccountUpdate accountUpdate);

        Task DeleteAccountAsync(AccountDelete accountDelete);

        Task<AccountGet> GetAccountAsync(int id);

        Task<List<AccountGet>> AccountAsync {  get; }
    }
}
