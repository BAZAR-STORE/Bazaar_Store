using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bazaar_Store.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private IProduct _product;

        public DetailsModel(IProduct service)
        {
            _product = service;
        }

        public product product { get; set; }
        public async Task OnGet(int Id)
        {
            product = await _product.GetProdect(Id);
        }
    }
}
