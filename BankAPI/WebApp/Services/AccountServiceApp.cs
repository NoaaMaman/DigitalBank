using Bank_Utility;
using BankAPI.Models.DTOS.AccountDTO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public class AccountServiceApp : BaseService, IAccountServicesApp
    {
        private readonly IHttpClientFactory _clientFactory;
        private string accountUrl;

        public AccountServiceApp(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            accountUrl = configuration.GetValue<string>("ServiceUrls:BankAPI");
        }

        Task<T> IAccountServicesApp.CreateAsync<T>(BankAPI.Models.DTOS.AccountDTO.RegisterNewAccountModel dto)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = DS.ApiType.POST,
                Data = dto,
                Url = accountUrl + "api/AccountAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = DS.ApiType.DELETE,
                Url = accountUrl + "api/AccountAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = DS.ApiType.GET,
                Url = accountUrl + "api/AccountAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = DS.ApiType.GET,
                Url = accountUrl + "api/AccountAPI/" + id
            });
        }

        Task<T> IAccountServicesApp.UpdateAsync<T>(BankAPI.Models.DTOS.AccountDTO.UpdateAccountModel dto)
        {
            return sendAsync<T>(new APIRequest()
            {
                ApiType = DS.ApiType.PUT,
                Data = dto,
                Url = accountUrl + "api/AccountAPI" + dto.Id
            });;
        }

        

        
    }
}
