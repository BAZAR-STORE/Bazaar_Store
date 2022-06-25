using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public int BarCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string DiscountPrice { get; set; }
        [Required]
        public string Description { get; set; }
        public Char TodaysDeals { get; set; }
        public string URL { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }

    }
}
