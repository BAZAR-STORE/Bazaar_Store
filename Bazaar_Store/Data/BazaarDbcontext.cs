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
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Prodect> Prodects { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }


        public BazaarDbcontext(DbContextOptions options) : base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasData(
              new Admin { Id = 1, UserName = "Admin", Email = "BazzarStore_Admin@Gmail.com", Password = "Admin123" , ConfirmPassword = "Admin123" , PhoneNumber = "85212636" }
             );

            modelBuilder.Entity<Company>().HasData(
                  new Company { Id = 1, UserName = "Nike", Email = "Nikecompany@Gmail.com", Password = "Nike123", Address = "Oregon", PhoneNumber = "584632", CommercialRegistrationNumber = 123456789 },
                  new Company { Id = 2, UserName = "IBM", Email = "IBMcompany@Gmail.com", Password = "IBM123", Address = "New York", PhoneNumber = "894201", CommercialRegistrationNumber = 987654321 }
                  );

            modelBuilder.Entity<Customer>().HasData(
             new Customer { Id = 1, UserName = "Haneen", Email = "Haneen@Gmail.com", Password = "Haneen123", ConfirmPassword = "Haneen123", PhoneNumber = "2154563" },
             new Customer { Id = 1, UserName = "Aladdin", Email = "Aladdin@Gmail.com", Password = "Aladdinn123", ConfirmPassword = "Aladdin123", PhoneNumber = "9876202" }
             );


        }
    }
}
