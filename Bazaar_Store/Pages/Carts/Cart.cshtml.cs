using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazaar_Store.Data;
using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bazaar_Store.Pages.Carts
{
    public class CartModel : PageModel
    {
        private readonly IEmail MailService;
        private readonly BazaarDataBase _context;
        public CartModel(BazaarDataBase context, IEmail Email)
        {
            _context = context;
            MailService = Email;
        }

        [BindProperty]
        public string CartCookie { get; set; }
        [BindProperty]
        public List<Product> CartProducts { get; set; }

        public async Task OnGet()
        {
            CartCookie = HttpContext.Request.Cookies[$"{User.Identity.Name}'CartsList"];
            if (CartCookie != null)
            {
                CartProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(CartCookie);
            }

        }
        public async Task OnPost()
        {
            string email = await _context.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Email).FirstOrDefaultAsync();
            CartCookie = HttpContext.Request.Cookies[$"{User.Identity.Name}'CartsList"];
            if (CartCookie != null)
            {
                CartProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(CartCookie);
            }
            await MailService.SendMail(email, CartProducts);
        }
    }
}
