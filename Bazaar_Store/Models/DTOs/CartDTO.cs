using System.Collections.Generic;

namespace Bazaar_Store.Models.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public string UserId { get; set; }
        // To Many to many Relation between Cart And Product
        public List<ProductDTO> Products { get; set; }
    }
}
