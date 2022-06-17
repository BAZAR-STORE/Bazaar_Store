using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar_Store.Models
{
    public class CartProduct
    {
        public int id { get; set; }
        [ForeignKey("Cart")]

        public int CartId { get; set; }
        [ForeignKey("Products")]

        public int ProductId { get; set; }
        public Cart Cart { get; set; }

        public Product Products { get; set; }

        public int Quantity { get; set; }
    }
}
