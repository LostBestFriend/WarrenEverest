// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(WarrenEverestContext))]
    [Migration("20220919181338_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DomainModels.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Address");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Cellphone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Country");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Email");

                    b.Property<bool>("EmailSms")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("EmailSms");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("FullName");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("PostalCode");

                    b.Property<bool>("Whatsapp")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Whatsapp");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
