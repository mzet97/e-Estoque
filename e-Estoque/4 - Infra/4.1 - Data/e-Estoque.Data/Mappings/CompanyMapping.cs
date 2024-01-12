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
                .HasColumnType("TEXT");

            builder.Property(c => c.DocId)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.IdCompanyAddress).IsRequired();

            builder
                .HasOne(x => x.CompanyAddress)
                .WithMany()
                .HasForeignKey(x => x.IdCompanyAddress);
        }
    }
}