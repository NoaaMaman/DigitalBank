using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        [BindProperty]
        public string Message { get; set; }
        public ConfirmEmailModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(string userID, string token)
        {
            var user = await this.userManager.FindByEmailAsync(userID);
            if(user != null)
            {
                var result = await this.userManager.ConfirmEmailAsync(user, token);

                if(result.Succeeded)
                {
                    this.Message =  "Email Adress is succefully confirm, now you can try login.";
                }
                return Page();
            }
            this.Message = "Failed to validate email.";
            return Page();
        }
    }
}
