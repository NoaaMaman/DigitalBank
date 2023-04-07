using BankAPI.Models;
using WebApplication.Models;
using WebApplication.Models;
using APIResponse = WebApplication.Models.APIResponse;

namespace WebApplication.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }

        public Task<T> sendAsync<T>(APIRequest aPIRequest);


    }
}
