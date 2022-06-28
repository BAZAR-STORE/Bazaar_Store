using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
      
        public string Address { get; set; }
    

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
    }
}
