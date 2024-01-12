using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.ShortDescription)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("TEXT");
        }
    }
}