﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId })
                .HasName("PK__order_it__837942D4996A257C");

            entity.ToTable("order_items", "sales");

            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.Property(e => e.Discount)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount");

            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("list_price");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_ite__order__3B75D760");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__order_ite__produ__3C69FB99");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OrderItem> entity);
    }
}