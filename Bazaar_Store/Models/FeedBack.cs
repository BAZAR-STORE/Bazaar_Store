
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaar_Store.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string FeedBackDescription { get; set; }
        public double Rating { get; set; }
        //ForeignKey
        public Product Product { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        //ForeignKey
       // public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

    }
}
