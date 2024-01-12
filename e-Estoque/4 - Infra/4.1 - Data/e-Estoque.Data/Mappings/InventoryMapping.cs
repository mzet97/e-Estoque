using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(c => c.DateOrder)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.IdProduct)
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.IdProduct);
        }
    }
}