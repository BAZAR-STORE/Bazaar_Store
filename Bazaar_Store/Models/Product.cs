using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class Product
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
        public string Desciption { get; set; }
        [Required]
        public Char TodaysDeals { get; set; }

        

    }
}
