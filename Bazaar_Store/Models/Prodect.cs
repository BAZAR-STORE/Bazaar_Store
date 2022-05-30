using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class Prodect
    {
        public int Id { get; set; }
        [Required]
        public double InStok { get; set; }
        [Required]
        public long BarCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool DiscountPrice { get; set; }
        [Required]
        public string ProductDesciption { get; set; }
        [Required]
        public bool TodaysDeals { get; set; }

        public int CompanyId { get; set; }

    }
}
