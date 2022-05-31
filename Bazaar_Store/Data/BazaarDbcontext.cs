using Bazaar_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazaar_Store.Data
{
    public class BazaarDbcontext : DbContext
    {
        

        public DbSet<Category> Categories { get; set; }

        public DbSet<Prodect> Prodects { get; set; }

       

        public BazaarDbcontext(DbContextOptions options) : base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<Prodect>().HasData(
                  new Prodect { Id = 1, Name = "Nike", Price = 12.0, BarCode = 12345 , DiscountPrice = "0%" , Desciption = "584632", TodaysDeals = 'F' },
                  new Prodect { Id = 2, Name = "IBM", Price = 11.3 , BarCode = 12346 , DiscountPrice = "15%" , Desciption = "894201", TodaysDeals = 'T' }
                  );

            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Shose", Desciption = "Haneen@Gmail.com" },
             new Category { Id = 2, Name = "T-shirt", Desciption = "Aladdin@Gmail.com" }
             );


        }
    }
}
