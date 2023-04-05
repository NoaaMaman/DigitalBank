using BankAPI.Models.DTOS.AccountDTO;
using WebApp.Services.IServices;

namespace WebApp.Services
{
    public interface IAccountServicesApp
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);

        Task<T> CreateAsync<T>(RegisterNewAccountModel dto);

        Task<T> UpdateAsync<T>(UpdateAccountModel dto);

        Task<T> DeleteAsync<T>(int id);

    }
    
    
}
