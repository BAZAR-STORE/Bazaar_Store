using Bazaar_Store.Data;
using Bazaar_Store.Models.DTOs;
using Bazaar_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Service
{
    public class CartService : ICart
    {
        private readonly BazaarDataBase _context;

        public CartService(BazaarDataBase context)
        {
            _context = context;
        }
        public async Task<CartDTO> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            CartDTO newCart = new CartDTO
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId
            };

            return newCart;
        }

        public async Task<List<CartDTO>> GetCarts()
        {
            List<CartDTO> carts = await _context.Carts.Select(cart => new CartDTO
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
                Products = cart.CartProducts.Select(cp => new ProductDTO
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    Description = cp.Products.Description,
                    URL = cp.Products.URL,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).ToListAsync();

            foreach (var item in carts)
            {
                item.TotalCost = ReturnTotalCost(item);
            }

            foreach (var item in carts)
            {
                item.TotalQuantity = GetProductQuantity(item);
            }

            await _context.SaveChangesAsync();

            return carts;
        }

        public async  Task<CartDTO> GetCart(int id)
        {
            CartDTO cart = await _context.Carts.Select(cart => new CartDTO
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
                Products = cart.CartProducts.Select(cp => new ProductDTO
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    Description = cp.Products.Description,
                    URL = cp.Products.URL,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(c => c.Id == id);

            Cart cartTotal = await _context.Carts.Where(x => x.Id == cart.Id ).FirstAsync();

            cartTotal.TotalCost = ReturnTotalCost(cart);

            cartTotal.TotalQuantity = GetProductQuantity(cart);

            await _context.SaveChangesAsync();

            cart = await _context.Carts.Select(cart => new CartDTO
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
                Products = cart.CartProducts.Select(cp => new ProductDTO
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    Description = cp.Products.Description,
                    URL = cp.Products.URL,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(c => c.Id == id);



            return cart;
        }

        public async Task<CartDTO> GetUserCart(string userId)
        {
            Cart userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (userCart == null)
            {
                return null;
            }
            CartDTO CartDTO = new CartDTO
            {
                Id = userCart.Id,
                TotalCost = userCart.TotalCost,
                TotalQuantity = userCart.TotalQuantity,
                UserId = userId
            };

            return CartDTO;
        }

        public async Task<CartDTO> UpdateCart(int id, Cart cart)
        {
            CartDTO CartDTO = new CartDTO
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId
            };
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CartDTO;
        }

        public async Task Delete(int id)
        {
            Cart cart = await _context.Carts.FindAsync(id);
            _context.Entry(cart).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToCart(int cartId, int productId)
        {
            var existsCartProduct = _context.CartProduct.Any(cp => cp.ProductId == productId && cp.CartId == cartId);
            Product productStock = await _context.Products.FindAsync(productId);

               
        }
        public async Task RemoveProductFromCart(int cartId, int productId)
        {
            var existsCartProduct = _context.CartProduct.Any(cp => cp.ProductId == productId && cp.CartId == cartId);
            if (existsCartProduct)
            {
                CartProduct removeProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
                Product productStock = await _context.Products.FindAsync(productId);
                if (removeProduct.Quantity > 1)
                {
                    removeProduct.Quantity -= 1;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Entry(removeProduct).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }
        }

        private double ReturnTotalCost(CartDTO cart)
        {
                List<int> QuantityList = _context.CartProduct.Where(cp => cp.CartId == cart.Id).Select(q => q.Quantity).ToList();
                double Total = 0;
                int count = 0;
                foreach (var item in cart.Products)
                {
                    Total += item.Price * QuantityList[0];
                    count++;
                }
                return Total;
        }

        private int GetProductQuantity(CartDTO cart)
        {
            int TotalQuantity = 0;

            List<int> cartProduct = _context.CartProduct.Where(cp => cp.CartId == cart.Id).Select(q => q.Quantity).ToList();
            foreach (var item in cartProduct)
            {
                TotalQuantity += item;
            }
            return TotalQuantity;
        }
    }
}
