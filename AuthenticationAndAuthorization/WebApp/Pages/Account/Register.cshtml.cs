using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            
        }

        [BindProperty]
        public RegisterViewModel registerViewModel { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) return Page();

            // Validating Email address (Optional)

            // Create the user 
            var user = new IdentityUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            var result = await this.userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                var confirmationToken = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.PageLink(pageName: "/Account/ConfirmEmail",
                    values: new { userId = user.Id, token = confirmationToken });

                var message = new MailMessage("noaamaman325158@gmail.com",
                    user.Email,
                    "Please confirm your email",
                    $"Please click on this link to confirm your email address: {confirmationLink}");

                using (var emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587))
                {
                    emailClient.Credentials = new NetworkCredential(
                        "noaamaman325158@gmail.com",
                        "wI4GpahFHd7VYXDj");

                    await emailClient.SendMailAsync(message);
                }

                return RedirectToPage("/Account/Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }

                return Page();
            }

        }
    }
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Adress")]
        public string Email{ get; set; }

        [Required]
        [DataType(dataType:DataType.Password)]
        public string Password{ get; set; }
    }


}
