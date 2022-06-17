using Bazaar_Store.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface ICart
    {
        Task<CartDTO> Create(Cart cart);
        Task<List<CartDTO>> GetCarts();
        Task<CartDTO> GetCart(int id);
        Task<CartDTO> UpdateCart(int id, Cart newCart);
        Task Delete(int id);
        Task<CartDTO> GetUserCart(string userId);
        Task AddProductToCart(int cartId, int productId);
        Task RemoveProductFromCart(int cartId, int productId);

    }
}
