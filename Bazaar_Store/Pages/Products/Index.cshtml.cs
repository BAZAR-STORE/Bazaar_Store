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
        private readonly IProduct _prouduct;
        private readonly ICategory _category;
        private readonly ICart _cart;
        public IndexModel(IProduct prouduct, ICategory category,ICart cart)
        {
            _prouduct = prouduct;
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

        public async Task<IActionResult> OnPost(int id , int cartId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartDTO cartData = await _cart.GetUserCart(userId);
            if (cartData == null)
            {
                Cart newCart = new Cart
                {
                    TotalCost = 0,
                    TotalQuantity = 0,
                    UserId = userId
                };

                cartData = await _cart.Create(newCart);
                await _cart.AddProductToCart(cartData.Id, id);
            }
            else
            {
                await _cart.AddProductToCart(cartData.Id, id);
            }
            CookieOptions cookieOptions = new CookieOptions();
            HttpContext.Response.Cookies.Append("count", cartData.TotalQuantity.ToString(), cookieOptions);
            return Redirect($"/Products?id={cartId}");
        }
    }
}


