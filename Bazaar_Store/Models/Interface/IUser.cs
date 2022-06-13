using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface IUser
    {
        Task<User> Create(User user);
        Task<List<User>> GetAll();
    }
}
