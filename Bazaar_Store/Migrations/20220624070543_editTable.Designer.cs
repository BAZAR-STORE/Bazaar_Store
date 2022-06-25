﻿// <auto-generated />
using System;
using Bazaar_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bazaar_Store.Migrations
{
    [DbContext(typeof(BazaarDataBase))]
    [Migration("20220624070543_editTable")]
    partial class editTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bazaar_Store.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Bazaar_Store.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Bazaar_Store.Models.CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("Bazaar_Store.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "Sport Shose",
                            Name = "Shose"
                        },
                        new
                        {
                            Id = 2,
                            Details = "roblox girl",
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 3,
                            Details = "Octa-core (1x2.84 GHz Kryo 585 & 3x2.42 GHz Kryo 585 & 4x1.8 GHz Kryo 585) , 6GB RAM , 128GB Storage",
                            Name = "Tablet PC"
                        },
                        new
                        {
                            Id = 4,
                            Details = "4-Cores Processor】 11th Generation Intel Core i5-1135G7, up to 4.2 GHz Turbo, 4 core, 8 thread, 8MB",
                            Name = "T-Barebone"
                        },
                        new
                        {
                            Id = 5,
                            Details = "L.A. Girl, Pro Eyeshadow Palette, Mastery, 1.23 oz (35 g)",
                            Name = "Eyeshadow"
                        },
                        new
                        {
                            Id = 6,
                            Details = "L'Oreal, Infallible 24H Fresh Wear, Foundation In A Powder, 120 Vanilla, 0.31 oz (9 g)",
                            Name = "T-Foundation"
                        });
                });

            modelBuilder.Entity("Bazaar_Store.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "is an American multinational corporation that is engaged in the design, development, manufacturing, and worldwide marketing and sales of footwear, apparel, equipment, accessories, and services. The company is headquartered near Beaverton, Oregon, in the Portland metropolitan area.[3] It is the world's largest supplier of athletic shoes and apparel and a major manufacturer of sports equipment, with revenue in excess of US$37.4 billion in its fiscal year 2020 (ending May 31, 2020).[4] As of 2020, it employed 76,700 people worldwide.[5] In 2020 the brand alone was valued in excess of $32 billion, making it the most valuable brand among sports businesses.[6] Previously, in 2017, the Nike brand was valued at $29.6 billion.[7] Nike ranked 89th in the 2018 Fortune 500 list of the largest United States corporations by total revenue.[8]The company was founded on January 25,1964, as Blue Ribbon Sports,by Bill Bowerman and Phil Knight,and officially became Nike,",
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 2,
                            Description = "is a Spanish clothing and accessories retailer based in Narón (A Coruña), Galicia founded in 1991.[1] It is part of Inditex, owner of Zara and Bershka brands. The name came from the word pull like pull from the shelf and bear",
                            Name = "IBM"
                        },
                        new
                        {
                            Id = 3,
                            Description = " HP, was an American multinational information technology company headquartered in Palo Alto, California. ",
                            Name = "HP"
                        },
                        new
                        {
                            Id = 4,
                            Description = " eyeliner, mascara, primer, lipstick, lipgloss, blush, foundation,",
                            Name = "L.A. Girl"
                        },
                        new
                        {
                            Id = 5,
                            Description = "L'Oréal S.A. (French pronunciation: ​[lɔʁeal]) is a French personal care company headquartered in Clichy, Hauts-de-Seine[2] with a registered office in Paris",
                            Name = "L'Oreal"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Dell is an American technology company that develops, sells, repairs, and supports computers and related products and services, and is owned by its parent company of Dell Technologies",
                            Name = "Deall"
                        });
                });

            modelBuilder.Entity("Bazaar_Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarCode")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TodaysDeals")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarCode = 34645768,
                            CategoryId = 1,
                            Description = "Comfort for running",
                            DiscountPrice = "0%",
                            InStock = 0,
                            Name = "Nike Shoes",
                            Price = 12.0,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 2,
                            BarCode = 4534676,
                            CategoryId = 1,
                            Description = "IBM P4 945G System Board For ThinkCentre A52 73P0780 41X0436",
                            DiscountPrice = "15%",
                            InStock = 0,
                            Name = "IBM",
                            Price = 11.300000000000001,
                            TodaysDeals = "T"
                        },
                        new
                        {
                            Id = 3,
                            BarCode = 985012,
                            CategoryId = 1,
                            Description = "easy to use",
                            DiscountPrice = "5%",
                            InStock = 0,
                            Name = "HP",
                            Price = 635.89999999999998,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 4,
                            BarCode = 1403875,
                            CategoryId = 2,
                            Description = "Safe on the skin",
                            DiscountPrice = "0%",
                            InStock = 0,
                            Name = "L.A. Girl",
                            Price = 9.0999999999999996,
                            TodaysDeals = "T"
                        },
                        new
                        {
                            Id = 5,
                            BarCode = 235752,
                            CategoryId = 2,
                            Description = "Safe on the skin",
                            DiscountPrice = "50%",
                            InStock = 0,
                            Name = "L'Oreal",
                            Price = 25.600000000000001,
                            TodaysDeals = "T"
                        },
                        new
                        {
                            Id = 7,
                            BarCode = 78413566,
                            CategoryId = 3,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 8,
                            BarCode = 78413566,
                            CategoryId = 3,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 9,
                            BarCode = 78413566,
                            CategoryId = 3,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 10,
                            BarCode = 78413566,
                            CategoryId = 4,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 11,
                            BarCode = 78413566,
                            CategoryId = 4,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 12,
                            BarCode = 78413566,
                            CategoryId = 4,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 13,
                            BarCode = 78413566,
                            CategoryId = 5,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 14,
                            BarCode = 78413566,
                            CategoryId = 5,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 15,
                            BarCode = 78413566,
                            CategoryId = 5,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 16,
                            BarCode = 78413566,
                            CategoryId = 6,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 17,
                            BarCode = 78413566,
                            CategoryId = 6,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 18,
                            BarCode = 78413566,
                            CategoryId = 6,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        },
                        new
                        {
                            Id = 19,
                            BarCode = 78413566,
                            CategoryId = 6,
                            Description = "Comfort for running",
                            DiscountPrice = "30%",
                            InStock = 0,
                            Name = "Deall",
                            Price = 400.5,
                            TodaysDeals = "F"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "administrator",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "editor",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "administrator"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "administrator"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "permissions",
                            ClaimValue = "delete",
                            RoleId = "administrator"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "editor"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "editor"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bazaar_Store.Models.Cart", b =>
                {
                    b.HasOne("Bazaar_Store.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bazaar_Store.Models.CartProduct", b =>
                {
                    b.HasOne("Bazaar_Store.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazaar_Store.Models.Product", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Bazaar_Store.Models.Product", b =>
                {
                    b.HasOne("Bazaar_Store.Models.Category", "Category")
                        .WithMany("ProductList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bazaar_Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bazaar_Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazaar_Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bazaar_Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bazaar_Store.Models.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Bazaar_Store.Models.Category", b =>
                {
                    b.Navigation("ProductList");
                });
#pragma warning restore 612, 618
        }
    }
}
