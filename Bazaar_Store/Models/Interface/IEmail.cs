using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface IEmail
    {
        public Task SendMail(string email, List<Product> products);
    }
}
