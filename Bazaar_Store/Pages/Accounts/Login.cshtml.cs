using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private IUser PeopleService;

        public LoginModel(IUser service)
        {
            PeopleService = service;
        }

        [BindProperty]
        public RegisterData Input { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User userlogin = new User()
            {
                Email = Input.Email,
                Password = Input.Password,
            };

            //  User p = await PeopleService.Create(user);
            var u = await PeopleService.Login(userlogin.Email, userlogin.Password);
            if (userlogin != null)
            {
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return Page();

            }
        }
        public class RegisterData
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
