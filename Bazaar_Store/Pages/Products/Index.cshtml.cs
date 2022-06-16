using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazaar_Store.Models;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bazaar_Store.Pages.Product
{
    public class productModel : PageModel
    {
        private ICategory _category;

        public productModel(ICategory service)
        {
            _category = service;
        }
        [BindProperty]
        public CategoryDTO categories { get; set; }
        public List<ProductDTO> products { get; set; }

        public async Task OnGet(int id)
        {
            CategoryDTO category = await _category.GetCategory(id);
            products = category.ProdectList;
        }
    }
}
