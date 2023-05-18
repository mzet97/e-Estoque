using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Estoque.Data.Mappings
{
    public class CustomerAdresssMapping : IEntityTypeConfiguration<CustomerAdress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomerAdress> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Street)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(c => c.Complement)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.Neighborhood)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.District)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.City)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.County)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.ZipCode)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.Latitude)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.Longitude)
               .IsRequired()
               .HasColumnType("varchar(250)");
        }
    }
}
