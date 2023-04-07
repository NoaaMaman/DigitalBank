using BankAPI.Models;
using WebApp.Models;
using WebApplication.Models;
using APIResponse = WebApplication.Models.APIResponse;

namespace WebApp.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }

        public Task<T> sendAsync<T>(APIRequest aPIRequest);


    }
}
