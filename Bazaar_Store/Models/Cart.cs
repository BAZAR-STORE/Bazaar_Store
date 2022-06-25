using Bazaar_Store.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar_Store.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public int TotalQuantity { get; set; }

        //ForeignKey
        public ApplicationUser User { get; set; }
        [ForeignKey("admin")]
        public string UserId { get; set; }
        //Navigation properties
        public List<CartProduct> CartProducts { get; set; }
    }
}
