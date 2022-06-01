namespace Bazaar_Store.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public string State { get; set; }
        public int TotalQuantity { get; set; }

    }
}
