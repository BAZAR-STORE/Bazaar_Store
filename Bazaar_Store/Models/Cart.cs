using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public double TotalCost { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public double TotalQuantity { get; set; }


        public enum PaymentType
        {
            
        }

    }
}
