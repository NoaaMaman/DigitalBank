using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication.Authorization;
using WebApplication.Models.DTOS;
using WebApplication.Pages.Account;

namespace WebApplication.Pages
{
    [Authorize(Policy = "ConsultantManagerOnly")]
    public class ConsultingBankerManagerModel : PageModel
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly ILogger<ConsultingBankerManagerModel> _logger;

        //[BindProperty]
        //public List<WeatherForecastDTO> WeatherForecastItems { get; set; }

        //public ConsultingBankerManagerModel(
        //    IHttpClientFactory httpClientFactory,
        //    IHttpContextAccessor httpContextAccessor,
        //    ILogger<ConsultingBankerManagerModel> logger)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _httpContextAccessor = httpContextAccessor;
        //    _logger = logger;
        //}

        //public async Task OnGetAsync()
        //{
        //    try
        //    {
        //        WeatherForecastItems = await InvokeEndPoint<List<WeatherForecastDTO>>("AuthenAuthorAPI", "WeatherForecast");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Failed to get weather forecast data.");
        //        // Handle the error, e.g. display an error message or redirect the user to an error page.
        //    }
        //}

        //private async Task<T> InvokeEndPoint<T>(string clientName, string url)
        //{
        //    // Get the JWT token from the session
        //    JwtToken token = null;

        //    var strTokenObj = _httpContextAccessor.HttpContext.Session.GetString("access_token");
        //    if (string.IsNullOrWhiteSpace(strTokenObj))
        //    {
        //        // Authenticate and get the token
        //        token = await Authenticate();
        //    }
        //    else
        //    {
        //        token = JsonConvert.DeserializeObject<JwtToken>(strTokenObj);
        //    }

        //    if (token == null ||
        //        string.IsNullOrWhiteSpace(token.AccessToken) ||
        //        token.ExpiresAt <= DateTime.UtcNow)
        //    {
        //        token = await Authenticate();
        //    }

        //    var httpClient = _httpClientFactory.CreateClient(clientName);
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        //    var response = await httpClient.GetAsync(url);
        //    response.EnsureSuccessStatusCode();

        //    var content = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<T>(content);
        //}
        //private async Task<JwtToken> Authenticate()
        //{
        //    //AUTHENTICATION AND GETTING THE TOKEN
        //    var httpClient = _httpClientFactory.CreateClient("AuthenAuthorAPI");
        //    var res = await httpClient.PostAsJsonAsync("auth", new Credential { UserName = "admin", Password = "password" });
        //    res.EnsureSuccessStatusCode();
        //    string strJwt = await res.Content.ReadAsStringAsync();
        //    HttpContext.Session.SetString("access_token",strJwt);

        //    return JsonConvert.DeserializeObject<JwtToken>(strJwt);
        //}

    }
}
