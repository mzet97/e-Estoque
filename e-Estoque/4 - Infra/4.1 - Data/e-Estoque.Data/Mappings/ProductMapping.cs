using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(5000)");

            builder.Property(c => c.ShortDescription)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.Weight)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.Height)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.Length)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(5000)");

            builder.Property(x => x.IdCategory)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.IdCategory);

            builder.Property(x => x.IdCompany)
                .IsRequired();

            builder
                .HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.IdCompany);
        }
    }
}
