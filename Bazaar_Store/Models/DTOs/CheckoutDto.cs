using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

namespace Bazaar_Store.Models.DTOs

{
    public class CheckoutDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum length is 3 character")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "You must provide a Zip code")]
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        public string UserId { get; set; }
        public int CartId { get; set; }
    }
}
