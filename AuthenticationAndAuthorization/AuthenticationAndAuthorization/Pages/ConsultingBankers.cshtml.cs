using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationAndAuthorization.Pages
{
    public class ConsultingBankersModel : PageModel
    {
        [Authorize(Policy = "MustBelongConsultingBanker")]
        public void OnGet()
        {
        }
    }
}
