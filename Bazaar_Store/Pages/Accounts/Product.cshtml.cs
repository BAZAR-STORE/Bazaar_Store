using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazaar_Store.Models;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bazaar_Store.Pages.Accounts
{
    public class ProductModel : PageModel
    {
        private readonly IProduct ProductServieces;
        private readonly ICategory CategoryServieces;

        [BindProperty]

        public List<Product> ProductList { get; set; }
        public List<CartProduct> CartProducts { get; set; }
        [BindProperty]
        public string CartCookie { get; set; }

        public ProductModel(IProduct product, ICategory category)
        {
            ProductServieces = product;
            CategoryServieces = category;
        }
        public async Task OnGet(int Id)
        {
            CartCookie = HttpContext.Request.Cookies[$"{User.Identity.Name}'CartsList"];
            if (CartCookie != null && Id == 0)
            {
                ProductList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(CartCookie);

            }
            else
            {
                ProductList = await ProductServieces.GetProdects();
            }
        }
    }
}
