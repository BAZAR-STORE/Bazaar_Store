using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.DTOs
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Enter UserName!")]
        [Display(Name = "User Name")]
        [MinLength(3)]
       
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
