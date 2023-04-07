using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    [Authorize(Policy="")]
    public class ConsultingBankerManagerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
