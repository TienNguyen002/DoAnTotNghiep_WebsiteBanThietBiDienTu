﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.ShortName)
                .IsRequired();

            builder.Property(p => p.UrlSlug)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
               .HasMaxLength(1000);

            builder.Property(p => p.ShortDescription)
                .IsRequired();

            builder.Property(p => p.Specification)
                .IsRequired();

            builder.Property(p => p.Amount)
                .HasMaxLength(500);

            builder.Property(p => p.SalePrice);

            builder.Property(p => p.Price);

            builder.Property(p => p.OrPrice)
                .IsRequired();

            builder.Property(p => p.SoldQuantity);

            builder.HasOne(p => p.Serie)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SerieId)
                .HasConstraintName("FK_Series_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Sale)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SaleId)
                .HasConstraintName("FK_Sales_Products")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Colors)
                .WithMany(c => c.Products)
                .UsingEntity(sp => sp.ToTable("ProductColors"));
        }
    }
}
