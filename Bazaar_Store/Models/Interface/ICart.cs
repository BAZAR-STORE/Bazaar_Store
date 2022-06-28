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
        Task UpdateCart(int id, Cart newCart);
        Task Delete(int id);
        Task<CartDTO> GetUserCart(string userId, int state);
        Task AddProductToCart(int cartId, int productId);
        Task RemoveProductFromCart(int cartId, int productId);
        int GetProductQuantity(int cartId, int productId);
        Task RemoveCartProduct(int cartId, int productId);
        bool GetCartById(int id);
        bool GetCartByUserId(string userId, int state);
    }
}
