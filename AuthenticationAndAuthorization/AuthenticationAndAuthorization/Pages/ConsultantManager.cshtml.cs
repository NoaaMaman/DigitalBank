using AuthenticationAndAuthorization.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationAndAuthorization.Pages
{
    [Authorize(Policy = "ConsultantManagerOnly")]
    public class ConsultingManager : PageModel
    {
        private readonly IHttpClientFactory httpClientFactory;

        [BindProperty]
        public List<weatherForecastDTO> WeatherForecastItems { get; set; }

        public ConsultingManager(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = httpClientFactory.CreateClient("OurWebAPI");
            WeatherForecastItems = await httpClient.GetFromJsonAsync<List<weatherForecastDTO>>("WeatherForecast");
        }
    }
}
