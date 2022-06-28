using Bazaar_Store.Models;

using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Invoices
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICart _cart;
        private readonly ICheckout _checkout;
        public IndexModel(ICart cart , ICheckout checkout)
        {
            _cart = cart;
            _checkout = checkout;
        }

        public Checkout Checkout { get; set; }
        public CartDTO Cart { get; set; }
      

        public class prod
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public async Task OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_cart.GetCartByUserId(userId, 0))
            {
                CartDTO userCart = await _cart.GetUserCart(userId, 0);
                if (userCart != null)
                {
                    bool checkUserCheckout = _checkout.GetUserCheckout(userId, userCart.Id);
                    if (checkUserCheckout)
                    {
                        Checkout = await _checkout.GetCheckoutForUser(userId, userCart.Id);
                    }
                    Cart = await _cart.GetUserCart(userId, 0);
                  
                }
            }
        }

        public async Task<ActionResult> OnPost(int cartId)
        {
            CartDTO cartDto = await _cart.GetCart(cartId);
            var userss = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Checkout userCheckoutCart = await _checkout.GetCheckoutForUser(userss, cartId);

            IList<prod> productlist = new List<prod>();
            foreach (var item in cartDto.Products)
            {
                var p = new prod
                {
                    Name = item.Name,
                    Price = item.Price
                };
                productlist.Add(p);
            }
            var dynamicTemplateData = new
            {
                Id = userCheckoutCart.Id,
            
             
                Address = userCheckoutCart.Address,
               
                Customer = userCheckoutCart.Name,
                Email = userCheckoutCart.Email,
                product = productlist,
                Total= cartDto.TotalCost
            };
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("22029874@student.ltuc.com", "Bazzar Team");
            msg.AddTo(userCheckoutCart.Email);
            msg.SetSubject("Bazzar order invoice");
            msg.SetTemplateId("d-bfdb9806d7a843ec853886fdf9c989cb");
            msg.SetTemplateData(dynamicTemplateData);
            await client.SendEmailAsync(msg);

            Cart cart = new Cart
            {
                Id = cartDto.Id,
                TotalCost = cartDto.TotalCost,
                TotalQuantity = cartDto.TotalQuantity,
                State = 1
            };
            await _cart.UpdateCart(cartId, cart);
            Response.Cookies.Delete("count");

            return Redirect("/Email");
        }
    }
}
