
using WebApplication.Models;
using WebApplication.Models.DTOS.AccountDTO;


namespace WebApplication.Services
{
    public interface IAccountServicesApp
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);

        Task<T> CreateAsync<T>(CreateAccountDTO dto);

        Task<T> UpdateAsync<T>(UpdateAccountModel dto);

        Task<T> DeleteAsync<T>(int id);

    }
    
    
}
