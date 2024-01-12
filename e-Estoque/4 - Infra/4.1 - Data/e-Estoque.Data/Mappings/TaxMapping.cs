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
                .HasColumnType("TEXT");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Percentage)
                .IsRequired()
                .HasColumnType("REAL");

            builder.Property(x => x.IdCategory)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Taxs)
                .HasForeignKey(x => x.IdCategory);
        }
    }
}