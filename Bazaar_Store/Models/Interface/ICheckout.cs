using Bazaar_Store.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Interface
{
    public interface ICheckout
    {
        Task<CheckoutDto> Create(Checkout checkout);
        Task<List<Checkout>> GetCheckouts();
        Task<Checkout> GetCheckout(int id);
        Task<Checkout> UpdateCheckout(int id, Checkout checkout);
        Task Delete(int id);
        Task<Checkout> GetCheckoutForUser(string userId, int cartId);
        bool GetUserCheckout(string userId, int cartId);
    }
}
