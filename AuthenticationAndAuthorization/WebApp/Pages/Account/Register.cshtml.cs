using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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
            if(!ModelState.IsValid) return Page();
            //Validating Email Adress
            //Create the User
            var user = new IdentityUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
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




        }
    }
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Adress")]
        public string? Email{ get; set; }

        [Required]
        [DataType(dataType:DataType.Password)]
        public string? Password{ get; set; }
    }


}
