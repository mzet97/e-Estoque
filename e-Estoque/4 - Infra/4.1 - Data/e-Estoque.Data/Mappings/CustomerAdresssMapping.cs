using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Estoque.Data.Mappings
{
    public class CustomerAddresssMapping : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Street)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Complement)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.Neighborhood)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.District)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.City)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.County)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.ZipCode)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.Latitude)
               .IsRequired()
               .HasColumnType("TEXT");

            builder.Property(c => c.Longitude)
               .IsRequired()
               .HasColumnType("TEXT");
        }
    }
}