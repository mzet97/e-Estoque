using e_Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Estoque.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.DocId)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(5000)");
        }
    }
}
