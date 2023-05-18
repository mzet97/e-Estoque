using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class SaleProductMapping : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.IdProduct)
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct);

            builder.Property(x => x.IdSale)
                .IsRequired();

            builder
                .HasOne(x => x.Sale)
                .WithMany(x => x.SaleProduct)
                .HasForeignKey(x => x.IdSale);

        }
    }
}
