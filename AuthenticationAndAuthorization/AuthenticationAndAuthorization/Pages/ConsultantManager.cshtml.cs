using AuthenticationAndAuthorization.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorization.Pages
{
    [Authorize(Policy = "ConsultantManagerOnly")]
    public class ConsultingManagerModel : PageModel
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ConsultingManagerModel(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public List<weatherForecastDTO> WeatherForecastItems { get; set; }

        public async Task OnGetAsync()
        {
            var httpClient = httpClientFactory.CreateClient("OurWebAPI");

            WeatherForecastItems = await httpClient.GetFromJsonAsync<List<weatherForecastDTO>>("WeatherForecast");
        }
    }
}
