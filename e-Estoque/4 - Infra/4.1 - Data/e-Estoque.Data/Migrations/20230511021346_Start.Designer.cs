﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using e_Estoque.Data.Context;

#nullable disable

namespace e_Estoque.Data.Migrations
{
    [DbContext(typeof(EstoqueDbContext))]
    [Migration("20230511021346_Start")]
    partial class Start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("e_Estoque.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("DocId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.CompanyAdress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid?>("CompanyId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId1");

                    b.HasIndex("IdCompany");

                    b.ToTable("CategoriesAdresss", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("DocId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.CustomerAdress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("IdCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("IdCustomer");

                    b.ToTable("CustomerAdress", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("ProductId1");

                    b.ToTable("inventories", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<decimal>("Height")
                        .HasColumnType("DECIMAL");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCompany")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<decimal>("Length")
                        .HasColumnType("DECIMAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INT");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Weight")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdCompany");

                    b.ToTable("Products", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INT");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaleType")
                        .HasColumnType("INT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal>("TotalTax")
                        .HasColumnType("DECIMAL");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.ToTable("Sales", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.SaleProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SaleId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSale");

                    b.HasIndex("SaleId1");

                    b.ToTable("SaleProduct", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Tax", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(5000)");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("DECIMAL");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("Taxs", "public");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.CompanyAdress", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Company", null)
                        .WithMany("CompanyAdresss")
                        .HasForeignKey("CompanyId1");

                    b.HasOne("e_Estoque.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("IdCompany")
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.CustomerAdress", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Customer", null)
                        .WithMany("CustomerAddress")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("e_Estoque.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Inventory", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .IsRequired();

                    b.HasOne("e_Estoque.Domain.Entities.Product", null)
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId1");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Product", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("e_Estoque.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .IsRequired();

                    b.HasOne("e_Estoque.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("IdCompany")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Sale", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.SaleProduct", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .IsRequired();

                    b.HasOne("e_Estoque.Domain.Entities.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("IdSale")
                        .IsRequired();

                    b.HasOne("e_Estoque.Domain.Entities.Sale", null)
                        .WithMany("SaleProduct")
                        .HasForeignKey("SaleId1");

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Tax", b =>
                {
                    b.HasOne("e_Estoque.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Company", b =>
                {
                    b.Navigation("CompanyAdresss");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Customer", b =>
                {
                    b.Navigation("CustomerAddress");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Product", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("e_Estoque.Domain.Entities.Sale", b =>
                {
                    b.Navigation("SaleProduct");
                });
#pragma warning restore 612, 618
        }
    }
}