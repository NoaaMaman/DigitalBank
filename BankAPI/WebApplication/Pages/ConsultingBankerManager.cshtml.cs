using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.DTO;

namespace WebApplication.Pages
{
    [Authorize(Policy= "ConsultantManagerOnly")]
    public class ConsultingBankerManagerModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public List<WeatherForecastDTO> WeatherForecastItems { get; set; }
        public ConsultingBankerManagerModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }
        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenAuthorAPI");
            WeatherForecastItems = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("weatherforecast");
        }

    }
}
