using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private IUser UserService;

        [BindProperty]
        public List<User> user { get; set; }

        public IndexModel(IUser service)
        {
            UserService = service;
        }
        public async Task OnGet()
        {
            user = await UserService.GetAll();
        }
    }
}
