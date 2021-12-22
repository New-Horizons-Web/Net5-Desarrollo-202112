﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts;
using EFCore.BikeStore.Web.API.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.BikeStore.Web.API.Infrastructure.Persistence.Contexts.Configurations
{
    public partial class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId })
                .HasName("PK__stocks__E68284D394196C58");

            entity.ToTable("stocks", "production");

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__stocks__product___37A5467C");

            entity.HasOne(d => d.Store)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__stocks__store_id__38996AB5");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Stock> entity);
    }
}