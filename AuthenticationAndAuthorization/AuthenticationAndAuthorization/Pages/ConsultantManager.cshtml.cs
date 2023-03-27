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
<<<<<<< HEAD
            var httpClient = httpClientFactory.CreateClient("OriginalWebAPI");
=======
            var httpClient = httpClientFactory.CreateClient("OurWebAPI");
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
            WeatherForecastItems = await httpClient.GetFromJsonAsync<List<weatherForecastDTO>>("WeatherForecast");
        }
    }
}
