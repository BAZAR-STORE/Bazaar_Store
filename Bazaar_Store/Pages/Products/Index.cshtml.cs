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
        public Category categories { get; set; }
        public async Task OnGet(int id)
        {
            categories = await _category.GetCategory(id);
        }
    }
}
