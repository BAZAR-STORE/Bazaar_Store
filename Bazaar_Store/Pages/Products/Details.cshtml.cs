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

        public Details details { get; set; }
        public async Task OnGet(int Id)
        {
            //  details = await _product.GetProdect(Id);
            //Details detail = new Product()
            //{
            //     Id = details.Id,
            //     Description = details.ProductDetails
            //};

            ////Details p = await _product.Create(detail);
            //detail = await _product.GetProdect(Id);
        }
        public class Details
        {
            public int Id { get; set; }

            public string ProductDetails { get; set; }

            public static implicit operator Details(Models.Product v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
