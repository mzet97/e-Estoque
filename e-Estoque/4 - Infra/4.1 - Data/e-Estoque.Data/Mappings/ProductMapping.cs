using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Estoque.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.ShortDescription)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.Weight)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.Height)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.Length)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.IdCategory)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
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