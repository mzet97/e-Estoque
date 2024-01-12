using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(c => c.SaleType)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(c => c.PaymentType)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(c => c.TotalPrice)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.TotalTax)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(c => c.DeliveryDate)
               .HasColumnType("TEXT");

            builder.Property(c => c.SaleDate)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.PaymentDate)
               .HasColumnType("TEXT");

            builder.Property(c => c.CreatedAt)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.UpdatedAt)
               .HasColumnType("TEXT");

            builder.Property(c => c.DeletedAt)
               .HasColumnType("TEXT");

            builder.Property(x => x.IdCustomer)
                .IsRequired();

            builder
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.IdCustomer);
        }
    }
}