using Bazaar_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazaar_Store.Data
{
    public class BazaarDbcontext : DbContext
    {


        public DbSet<Company> Companies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }



        public BazaarDbcontext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Product>().HasData(
                  new Product { Id = 1, Name = "Nike Shoes", Price = 12.0, BarCode = 34645768, DiscountPrice = "0%", Description = "Comfort for running", TodaysDeals = 'F' },
                  new Product { Id = 2, Name = "IBM Motherboard", Price = 11.3, BarCode = 4534676, DiscountPrice = "15%", Description = "IBM P4 945G System Board For ThinkCentre A52 73P0780 41X0436", TodaysDeals = 'T' }
                  );

            modelBuilder.Entity<Company>().HasData(
             new Company
             {
                 Id = 1,
                 Name = "Nike",
                 Description = "" + "is an American multinational corporation that is engaged in the design, development, manufacturing, and worldwide marketing and sales of footwear, apparel, equipment, accessories, and services. The company is headquartered near Beaverton, Oregon, in the Portland metropolitan area.[3] It is the world's largest supplier of athletic shoes and apparel and a major manufacturer of sports equipment, with revenue in excess of US$37.4 billion in its fiscal year 2020 (ending May 31, 2020).[4] As of 2020, it employed 76,700 people worldwide.[5] In 2020 the brand alone was valued in excess of $32 billion, making it the most valuable brand among sports businesses.[6] Previously, in 2017, the Nike brand was valued at $29.6 billion.[7] Nike ranked 89th in the 2018 Fortune 500 list of the largest United States corporations by total revenue.[8]The company was founded on January 25,1964, as Blue Ribbon Sports,by Bill Bowerman and Phil Knight,and officially became Nike,"
             },
             new Company { Id = 2, Name = "Pull&Bear", Description = "is a Spanish clothing and accessories retailer based in Narón (A Coruña), Galicia founded in 1991.[1] It is part of Inditex, owner of Zara and Bershka brands. The name came from the word pull like pull from the shelf and bear" }
             );

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Shose", Details = "Sport Shose" },
            new Category { Id = 2, Name = "T-shirt", Details = "roblox girl" }

            );


        }
    }
}
