using Bazaar_Store.Models;
using Bazaar_Store.Models.Service;
using Bazaar_Store.Models.Serviece;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace BazaarTest
{
    public class UnitTest1 : Mock
    {
        private readonly IConfiguration _configuration;

        [Fact]
        public void GetProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            product.Name = "New sho";
            var service = new ProductServieces(_db, _configuration);
            Product NewProduct = service.GetProdect(product.Id).Result;
            Assert.Equal(NewProduct.Name, product.Name);
        }

        [Fact]
        public void GetCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            category.Name = "New category";
            var service = new CategoryServieces(_db);
            Category Newcategory = service.GetCategory(category.Id).Result;
            Assert.Equal(category.Name, Newcategory.Name);
        }

        [Fact]
        public async void UpdatProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            string OldProductName = product.Name;
            product.Name = "New Laptop";
            var service = new ProductServieces(_db, _configuration);
            product = await service.UpdateProduct(product);
            product = service.GetProdect(product.Id).Result;
            Assert.NotEqual(OldProductName, product.Name);
        }

        [Fact]
        public async void TestUpdatingCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            string OldCategoryName = category.Name;
            category.Name = "New Category";
            var service = new CategoryServieces(_db);
            category = await service.UpdateCategory(category);
            category = service.GetCategory(category.Id).Result;
            Assert.NotEqual(OldCategoryName, category.Name);
        }

        [Fact]
        public async void DeleteProduct()
        {
            Product product = (Product)CreateAndSaveTestProduct().Result;
            int id = product.Id;
            var repository = new ProductServieces(_db, _configuration);
            await repository.Delete(id);
            product = await repository.GetProdect(id);
            Assert.Null(product);
        }

        [Fact]
        public async void DeleteCategory()
        {
            Category category = (Category)CreateAndSaveTestCategory().Result;
            int id = category.Id;
            var repository = new CategoryServieces(_db);
            await repository.Delete(id);
            category = await repository.GetCategory(id);
            Assert.Null(category);
        }
    }
}
