using BankAPI.Models;
using WebApp.Models;
using APIResponse = WebApp.Models.APIResponse;

namespace WebApp.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }

        public Task<T> sendAsync<T>(APIRequest aPIRequest);


    }
}
