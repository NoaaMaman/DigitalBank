using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationAndAuthorization.Pages
{
    public class SettingsModel : PageModel
    {
        [Authorize(Policy ="AdminOnly")]
        public void OnGet()
        {
        }
    }
}
