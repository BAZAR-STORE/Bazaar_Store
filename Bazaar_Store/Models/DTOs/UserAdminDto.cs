using System.Collections.Generic;

namespace Bazaar_Store.Models.DTOs
{
    public class UserAdminDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IList<string> Roles { get; internal set; }
    }
}
