using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class TaxMapping : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(5000)");

            builder.Property(c => c.Percentage)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(x => x.IdCategory)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.IdCategory);

        }
    }
}
