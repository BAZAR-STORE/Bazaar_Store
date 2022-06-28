using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategory _category;
        private readonly ICart _cart;
        public IndexModel(ICategory category, ICart cart)
        {
            _category = category;
            _cart = cart;
        }

        [BindProperty]
        public List<Category> category { get; set; }

        public async Task OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_cart.GetCartByUserId(userId, 0))
            {
                CartDTO cartData = await _cart.GetUserCart(userId, 0);
                if (cartData != null)
                {
                    HttpContext.Response.Cookies.Append("count", cartData.TotalQuantity.ToString());
                }
            }
            category = await _category.GetCategories();
        }

        public IActionResult OnPost(int id)
        {
            return Redirect($"/Products/{id}");
        }
    }
}
