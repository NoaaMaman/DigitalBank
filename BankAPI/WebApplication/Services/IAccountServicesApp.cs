
using WebApplication.Models;
using WebApplication.Models.DTOS;



namespace WebApplication.Services
{
    public interface IAccountServicesApp
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);

        Task<T> CreateAsync<T>(CreateAccountDTO dto);

        Task<T> UpdateAsync<T>(UpdateAccountDTO dto);

        Task<T> DeleteAsync<T>(int id);
        
    }
    
    
}
