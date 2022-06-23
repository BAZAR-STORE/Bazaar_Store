using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        public string Description { get; set; }
        public int BarCode { get; set; }
        public IFormFile File { get; set; }
        public string ImgUrl { get; set; }
      
        public string CategoryName { get; set; }

        public List<Category> Categories { get; set; }
    }
}
