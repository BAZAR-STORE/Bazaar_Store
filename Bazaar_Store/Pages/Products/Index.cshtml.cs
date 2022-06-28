using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Products
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
        public List<Product> Product { get; set; }

        public int CartId { get; set; }
        public async Task OnGet(int id)
        {
            Category category = await _category.GetCategory(id);
            Product = category.ProductList;
            CartId = id;
        }

        public async Task<IActionResult> OnPost(int id, int cartId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartDTO cartData = null;
            if (_cart.GetCartByUserId(userId, 0))
            {
                cartData = await _cart.GetUserCart(userId, 0);
            }

            if (cartData == null)
            {
                Cart newCart = new Cart
                {
                    TotalCost = 0,
                    TotalQuantity = 0,
                    UserId = userId,
                    State = 0
                };
                cartData = await _cart.Create(newCart);
                await _cart.AddProductToCart(cartData.Id, id);
            }
            else
            {
                await _cart.AddProductToCart(cartData.Id, id);
            }
            if (cartData != null)
            {
                HttpContext.Response.Cookies.Append("count", cartData.TotalQuantity.ToString());
            }

            return Redirect($"/Products/{cartId}");
        }
    }
}


