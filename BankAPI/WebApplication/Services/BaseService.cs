﻿using BankAPI.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services.IServices;
using APIResponse = WebApplication.Models.APIResponse;
using Bank_Utility;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }
        APIResponse IBaseService.responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.responseModel = new APIResponse();
        }

        public async Task<T> sendAsync<T>(APIRequest aPIRequest)
        {
            try
            {
                var client = httpClient.CreateClient();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                // Debug statement to print the URL value
                Console.WriteLine($"URL: {aPIRequest.Url}");

                // Check that the URL contains a valid port number
                if (!Uri.TryCreate(aPIRequest.Url, UriKind.Absolute, out Uri uri) || uri.Port < 0 || uri.Port > 65535)
                {
                    throw new UriFormatException("Invalid URI: Invalid port specified.");
                }

                message.RequestUri = uri;
                if (aPIRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(aPIRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (aPIRequest.ApiType)
                {
                    case DS.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case DS.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case DS.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);

                return APIResponse;

            }
            catch (Exception e)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);

                return APIResponse;
            }
        }

        
    }
}