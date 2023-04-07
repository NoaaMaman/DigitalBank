using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    [Authorize(Policy = "MustBelongConsultingBanker")]
   
    public class HumanResourceModel : PageModel
    {
        


        public void OnGet()
        {
        }
    }
}
