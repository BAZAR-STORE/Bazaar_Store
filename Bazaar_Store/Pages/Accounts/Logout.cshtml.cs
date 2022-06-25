using Bazaar_Store.Models.Interface;
using Bazaar_Store.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _userService;

        public LogoutModel(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> OnGet()
        {
            await _userService.Logout();
            Response.Cookies.Delete("count");

            return Redirect("/");
        }
    }
}
