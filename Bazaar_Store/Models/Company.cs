using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public long PhoneNumber { get; set; }
        [Required]
        public int CommercialRegistrationNumber { get; set; }

        public List<Prodect> Prodect { get; set; }

       
    }
}
