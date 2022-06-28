using Bazaar_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bazaar_Store.Data
{
    public class BazaarDataBase : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
    

        public DbSet<Category> Categories { get; set; }


        public BazaarDataBase(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            


            modelBuilder.Entity<Product>().HasData(
                  new Product { Id = 1, Name = "Nike Shoes", Price = 12.0, BarCode = 34645768, DiscountPrice = "0%", Description = "Comfort for running", TodaysDeals = 'F' ,CategoryId = 1,URL= "https://icon-library.com/images/120-512_84746.png",InStock=23 },
                  new Product { Id = 2, Name = "IBM", Price = 11.3, BarCode = 4534676, DiscountPrice = "15%", Description = "IBM P4 945G System Board For ThinkCentre A52 73P0780 41X0436", TodaysDeals = 'T', CategoryId = 1, URL = "https://icon-library.com/images/120-512_84746.png" },
                  new Product { Id = 3, Name = "HP", Price = 635.9, BarCode = 985012, DiscountPrice = "5%", Description = "easy to use", TodaysDeals = 'F', CategoryId = 1, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 56 },
                  new Product { Id = 4, Name = "L.A. Girl", Price = 9.1, BarCode = 1403875, DiscountPrice = "0%", Description = "Safe on the skin", TodaysDeals = 'T' , CategoryId = 2, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 246},
                  new Product { Id = 5, Name = "L'Oreal", Price =25.6, BarCode = 0235752, DiscountPrice = "50%", Description = "Safe on the skin", TodaysDeals = 'T' , CategoryId = 2, InStock = 287 },
                  new Product { Id = 7, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 3, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 98 },
                  new Product { Id = 8, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 3, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 9 },
                  new Product { Id = 9, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 3, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 86 },
                  new Product { Id = 10, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 4, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 21 },
                  new Product { Id = 11, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 4, InStock = 62 },
                  new Product { Id = 12, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 4, InStock = 74 },
                  new Product { Id = 13, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 5, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 82 },
                  new Product { Id = 14, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 5, InStock = 2359 },
                  new Product { Id = 15, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 5, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 23 },
                  new Product { Id = 16, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 6, InStock = 23 },
                  new Product { Id = 17, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 6, InStock = 93 },
                  new Product { Id = 18, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 6, URL = "https://icon-library.com/images/120-512_84746.png", InStock = 12 },
                  new Product { Id = 19, Name = "Deall", Price = 400.50, BarCode = 78413566, DiscountPrice = "30%", Description = "Comfort for running", TodaysDeals = 'F', CategoryId = 6, InStock = 8 }
                  );

            modelBuilder.Entity<Company>().HasData(
             new Company { Id = 1, Name = "Nike", Description = "" + "is an American multinational corporation that is engaged in the design, development, manufacturing, and worldwide marketing and sales of footwear, apparel, equipment, accessories, and services. The company is headquartered near Beaverton, Oregon, in the Portland metropolitan area.[3] It is the world's largest supplier of athletic shoes and apparel and a major manufacturer of sports equipment, with revenue in excess of US$37.4 billion in its fiscal year 2020 (ending May 31, 2020).[4] As of 2020, it employed 76,700 people worldwide.[5] In 2020 the brand alone was valued in excess of $32 billion, making it the most valuable brand among sports businesses.[6] Previously, in 2017, the Nike brand was valued at $29.6 billion.[7] Nike ranked 89th in the 2018 Fortune 500 list of the largest United States corporations by total revenue.[8]The company was founded on January 25,1964, as Blue Ribbon Sports,by Bill Bowerman and Phil Knight,and officially became Nike," },
             new Company { Id = 2, Name = "IBM", Description = "is a Spanish clothing and accessories retailer based in Narón (A Coruña), Galicia founded in 1991.[1] It is part of Inditex, owner of Zara and Bershka brands. The name came from the word pull like pull from the shelf and bear" },
             new Company { Id = 3, Name = "HP", Description = " HP, was an American multinational information technology company headquartered in Palo Alto, California. " },
             new Company { Id = 4, Name = "L.A. Girl", Description = " eyeliner, mascara, primer, lipstick, lipgloss, blush, foundation," },
             new Company { Id = 5, Name = "L'Oreal", Description = "L'Oréal S.A. (French pronunciation: ​[lɔʁeal]) is a French personal care company headquartered in Clichy, Hauts-de-Seine[2] with a registered office in Paris" },
             new Company { Id = 6, Name = "Deall", Description = "Dell is an American technology company that develops, sells, repairs, and supports computers and related products and services, and is owned by its parent company of Dell Technologies" }
             );

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Shose", Details = "Sport Shose" },
            new Category { Id = 2, Name = "Clothes", Details = "roblox girl" },
            new Category { Id = 3, Name = "Tablet PC", Details = "Octa-core (1x2.84 GHz Kryo 585 & 3x2.42 GHz Kryo 585 & 4x1.8 GHz Kryo 585) , 6GB RAM , 128GB Storage" },
            new Category { Id = 4, Name = "T-Barebone", Details = "4-Cores Processor】 11th Generation Intel Core i5-1135G7, up to 4.2 GHz Turbo, 4 core, 8 thread, 8MB" },
            new Category { Id = 5, Name = "Eyeshadow", Details = "L.A. Girl, Pro Eyeshadow Palette, Mastery, 1.23 oz (35 g)" },
            new Category { Id = 6, Name = "T-Foundation", Details = "L'Oreal, Infallible 24H Fresh Wear, Foundation In A Powder, 120 Vanilla, 0.31 oz (9 g)" }

            );
            modelBuilder.Entity<CartProduct>().HasKey(
          CartProduct => new { CartProduct.CartId, CartProduct.ProductId }
          );

            SeedRoles(modelBuilder, "administrator", "create", "update", "delete");
            SeedRoles(modelBuilder, "editor", "create", "update");
            SeedRoles(modelBuilder, "user", "create");


        }

        private int id = 1;
        private void SeedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()

            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            var RoleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = id++,
                RoleId = role.Id,
                ClaimType = "permissions",
                ClaimValue = permission
            }
            ).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(RoleClaims);
        }
    }
}
