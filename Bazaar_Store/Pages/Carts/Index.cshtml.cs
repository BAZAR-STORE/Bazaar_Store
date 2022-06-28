using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Bazaar_Store.Pages.Carts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICart _cart;

        public IndexModel(ICart cart)
        {
            _cart = cart;
        }

        public CartDTO Cart { get; set; }

        public async Task OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Zero mean user cart is open
            if (_cart.GetCartByUserId(userId, 0))
            {
                CartDTO userCart = await _cart.GetUserCart(userId, 0);
                if (userCart != null)
                {
                    Cart = await _cart.GetCart(userCart.Id);
                    foreach (var item in Cart.Products)
                    {
                        item.Quantity = _cart.GetProductQuantity(Cart.Id, item.Id);
                    }
                }
                if (Cart == null)
                {
                    Response.Cookies.Delete("count");
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(int cartId ,int productId)
        {
            await _cart.RemoveProductFromCart(cartId , productId);

            return Redirect("/Carts");
        }

        public async Task<IActionResult> OnPostDeleteAll(int cartId)
        {
            await _cart.Delete(cartId);
            return Redirect("/Carts");
        }
        public async Task<IActionResult> OnPostRemove(int cartId, int productId)
        {
            await _cart.RemoveCartProduct(cartId, productId);
            return Redirect("/Carts");
        }
        public async Task<IActionResult> OnPostAdd(int cartId, int productId)
        {
            await _cart.AddProductToCart(cartId, productId);
            return Redirect("/Carts");
        }
    }
}
