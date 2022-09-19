using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    internal class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(customer => customer.FullName)
                .IsRequired()
                .HasColumnName("FullName")
                .HasColumnType("text");

            builder.Property(customer => customer.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(60)");

            builder.HasIndex(customer => customer.Email)
                .IsUnique();

            builder.Property(customer => customer.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.HasIndex(customer => customer.Cpf)
                .IsUnique();

            builder.Property(customer => customer.Cellphone)
                .IsRequired()
                .HasColumnName("Cellphone")
                .HasColumnType("text");

            builder.Property(customer => customer.DateOfBirth)
                .IsRequired()
                .HasColumnName("DateOfBirth");

            builder.Property(customer => customer.EmailSms)
                .IsRequired()
                .HasColumnName("EmailSms");

            builder.Property(customer => customer.Whatsapp)
                .IsRequired()
                .HasColumnName("Whatsapp");

            builder.Property(customer => customer.Country)
                .IsRequired()
                .HasColumnName("Country")
                .HasColumnType("text");

            builder.Property(customer => customer.City)
                .IsRequired()
                .HasColumnName("City")
                .HasColumnType("text");

            builder.Property(customer => customer.PostalCode)
                .IsRequired()
                .HasColumnName("PostalCode")
                .HasColumnType("varchar(11)");

            builder.Property(customer => customer.Address)
                .IsRequired()
                .HasColumnName("Address")
                .HasColumnType("text");

            builder.Property(customer => customer.Number)
                .IsRequired()
                .HasColumnName("number");
        }
    }
}
