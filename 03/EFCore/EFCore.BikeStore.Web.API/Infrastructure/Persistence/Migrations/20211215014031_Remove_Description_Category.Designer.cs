﻿// <auto-generated />
using System;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.BikeStore.Web.API.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BikestoresContext))]
    [Migration("20211215014031_Remove_Description_Category")]
    partial class Remove_Description_Category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("brand_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("brand_name");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("brands", "production");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId");

                    b.ToTable("categories", "production");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("zip_code");

                    b.HasKey("CustomerId");

                    b.ToTable("customers", "sales");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("order_date");

                    b.Property<byte>("OrderStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("order_status");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("date")
                        .HasColumnName("required_date");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("date")
                        .HasColumnName("shipped_date");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("orders", "sales");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("discount");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("list_price");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ItemId")
                        .HasName("PK__order_it__837942D4996A257C");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items", "sales");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("list_price");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint")
                        .HasColumnName("model_year");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products", "production");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Active")
                        .HasColumnType("tinyint")
                        .HasColumnName("active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("manager_id");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.HasKey("StaffId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StoreId");

                    b.HasIndex(new[] { "Email" }, "UQ__staffs__AB6E616466423B8F")
                        .IsUnique();

                    b.ToTable("staffs", "sales");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Stock", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("StoreId", "ProductId")
                        .HasName("PK__stocks__E68284D394196C58");

                    b.HasIndex("ProductId");

                    b.ToTable("stocks", "production");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("store_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("state");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("store_name");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("zip_code");

                    b.HasKey("StoreId");

                    b.ToTable("stores", "sales");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Order", b =>
                {
                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__orders__customer__3D5E1FD2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Staff", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK__orders__staff_id__3E52440B")
                        .IsRequired();

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__orders__store_id__3F466844")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Staff");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.OrderItem", b =>
                {
                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__order_ite__order__3B75D760")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__order_ite__produ__3C69FB99")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Product", b =>
                {
                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK__products__brand___398D8EEE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__products__catego__3A81B327")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Staff", b =>
                {
                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Staff", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__staffs__manager___403A8C7D");

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Store", "Store")
                        .WithMany("Staff")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__staffs__store_id__412EB0B6")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Stock", b =>
                {
                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__stocks__product___37A5467C")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Store", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__stocks__store_id__38996AB5")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Staff", b =>
                {
                    b.Navigation("InverseManager");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities.Store", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Staff");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
