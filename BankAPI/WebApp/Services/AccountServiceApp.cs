﻿using Bank_Utility;

using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

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

        async Task<T> IAccountServicesApp.CreateAsync<T>(RegisterNewAccountModel dto)
        {
            return await sendAsync<T>(new APIRequest()
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

        Task<T> IAccountServicesApp.UpdateAsync<T>(UpdateAccountModel dto)
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