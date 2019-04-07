﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S_Buck_HW_4;

namespace S_Buck_HW_4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190407125916_UserStockFavorites")]
    partial class UserStockFavorites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.StockCompany", b =>
                {
                    b.Property<string>("Symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.HasKey("Symbol");

                    b.ToTable("StockCompanies");
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStock", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("Symbol");

                    b.Property<decimal>("Basis");

                    b.Property<int>("Shares");

                    b.HasKey("UserID", "Symbol");

                    b.HasIndex("Symbol");

                    b.ToTable("UserStocks");
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStockFavorite", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("Symbol");

                    b.HasKey("UserID", "Symbol");

                    b.HasIndex("Symbol");

                    b.ToTable("UserStockFavorites");
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStockTrade", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<string>("Symbol");

                    b.Property<DateTime>("TradeDateTime");

                    b.Property<decimal>("Price");

                    b.Property<int>("Shares");

                    b.HasKey("UserID", "Symbol", "TradeDateTime");

                    b.HasIndex("Symbol");

                    b.ToTable("UserStockTrades");
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStock", b =>
                {
                    b.HasOne("S_Buck_HW_4.Models.Database.StockCompany", "StockCompany")
                        .WithMany()
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S_Buck_HW_4.Models.Database.User", "User")
                        .WithMany("Stocks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStockFavorite", b =>
                {
                    b.HasOne("S_Buck_HW_4.Models.Database.StockCompany", "StockCompany")
                        .WithMany()
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S_Buck_HW_4.Models.Database.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S_Buck_HW_4.Models.Database.UserStockTrade", b =>
                {
                    b.HasOne("S_Buck_HW_4.Models.Database.StockCompany", "StockCompany")
                        .WithMany()
                        .HasForeignKey("Symbol")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S_Buck_HW_4.Models.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S_Buck_HW_4.Models.Database.UserStock", "UserStock")
                        .WithMany("UserStockTrades")
                        .HasForeignKey("UserID", "Symbol")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
