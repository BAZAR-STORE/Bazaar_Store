using Bazaar_Store.Data;
using Bazaar_Store.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BazaarTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly BazaarDataBase _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new BazaarDataBase(
                new DbContextOptionsBuilder<BazaarDataBase>().UseSqlServer(_connection)
                 
              // .UseSqlServer(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Product> CreateAndSaveTestProduct()
        {
            var product = new Product { Id = 10, Name = "laptop", Description = "gaming laptop", BarCode = 569841, DiscountPrice = "25%", TodaysDeals = 'T', CategoryId = 2 };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, product.Id); 
            return product;
        }

        protected async Task<Category> CreateAndSaveTestCategory()
        {
            var category = new Category {Id=10,Name = "electronics", Details = "electronics category" };
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, category.Id); 
            return category;
        }
    }
    
}
