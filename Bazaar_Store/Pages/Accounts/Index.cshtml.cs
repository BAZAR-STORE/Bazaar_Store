using Bazaar_Store.Models.Interface;
using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public LoginDto loginData { get; set; }

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (loginData.Username != null && loginData.Password != null)
            {
                var user = await _userService.Authenticate(loginData.Username, loginData.Password);
                if (user == null)
                {
                    ModelState.AddModelError("loginData.Password", "Password and username not match");
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Redirect("/index");
        }
    }
}
