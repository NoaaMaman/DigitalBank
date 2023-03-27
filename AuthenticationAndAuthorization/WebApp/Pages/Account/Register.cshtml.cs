using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.Net;
using System.Net.Mail;
=======
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710

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
<<<<<<< HEAD
            if (!ModelState.IsValid) return Page();

            // Validating Email address (Optional)

            // Create the user 
=======
            if(!ModelState.IsValid) return Page();
            //Validating Email Adress
            //Create the User
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
            var user = new IdentityUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
<<<<<<< HEAD

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

=======
            var result =await this.userManager.CreateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToPage("/Account/Register");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                return Page();
            }




>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
        }
    }
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Adress")]
<<<<<<< HEAD
        public string Email{ get; set; }

        [Required]
        [DataType(dataType:DataType.Password)]
        public string Password{ get; set; }
=======
        public string? Email{ get; set; }

        [Required]
        [DataType(dataType:DataType.Password)]
        public string? Password{ get; set; }
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
    }


}
