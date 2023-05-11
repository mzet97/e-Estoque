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
                .HasColumnType("DECIMAL");

            builder.Property(c => c.TotalTax)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(c => c.DeliveryDate)
               .HasColumnType("datetime2");

            builder.Property(c => c.SaleDate)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.Property(c => c.PaymentDate)
               .HasColumnType("datetime2");

            builder.Property(c => c.CreatedAt)
               .IsRequired()
               .HasColumnType("datetime2");

            builder.Property(c => c.UpdatedAt)
               .HasColumnType("datetime2");

            builder.Property(c => c.DeletedAt)
               .HasColumnType("datetime2");

            builder.Property(x => x.IdCustomer)
                .IsRequired();

            builder
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.IdCustomer);
        }
    }
}
