using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.DTOs
{
    // We did not use this in the demo
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IList<string> Roles { get; set; }
    }
}