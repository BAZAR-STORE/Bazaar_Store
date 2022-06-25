using Bazaar_Store.Models.Interface;
using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class SignupModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public RegisterDto registerData { get; set; }

        public SignupModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                 RedirectToAction("Index", "Auth");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (registerData.UserName != null && registerData.Email != null && registerData.Password != null)
            {
                await _userService.Register(registerData, this.ModelState);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

           return Redirect("/accounts");
        }
    }
}
