using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private IUser PeopleService;

        public RegisterModel(IUser service)
        {
            PeopleService = service;
        }

        [BindProperty]
        public RegisterData Input { get; set; }
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            User user = new User()
            {
                Email = Input.Email,
                Name = Input.Name,
                Password = Input.Password,
                Age = Input.Age
            };

            User p = await PeopleService.Create(user);

            // I will leave it for your exploration .... 
        }

        public class RegisterData
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
        }
    }
}
