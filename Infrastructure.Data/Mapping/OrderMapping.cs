﻿using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(order => order.Id);

            builder.HasIndex(order => order.LiquidateAt);

            builder.Property(order => order.Quotes)
                    .IsRequired()
                    .HasColumnName("Quotes");

            builder.Property(order => order.UnitPrice)
                   .IsRequired()
                   .HasColumnName("UnitPrice");

            builder.Property(order => order.NetValue)
                   .IsRequired()
                   .HasColumnName("NetValue");

            builder.Property(order => order.LiquidateAt)
                   .IsRequired()
                   .HasColumnName("LiquidateAt");

            builder.Property(order => order.Direction)
                   .IsRequired()
                   .HasColumnName("Direction");

            builder.HasOne(order => order.Product)
                    .WithMany(product => product.Orders)
                    .HasForeignKey(order => order.ProductId);

            builder.Property(order => order.ProductId)
                   .IsRequired()
                   .HasColumnName("ProductId");

            builder.HasOne(order => order.Portfolio)
                   .WithMany(portfolio => portfolio.Orders)
                   .HasForeignKey(order => order.PortfolioId);

            builder.Property(order => order.PortfolioId)
                   .IsRequired()
                   .HasColumnName("PorfolioId");
        }
    }
}
