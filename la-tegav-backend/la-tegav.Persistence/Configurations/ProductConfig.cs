using la_tegav.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace la_tegav.Persistence.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("TB_Product");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("[NVARCHAR](25)")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("[NVARCHAR](255)");

        builder.Property(x => x.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(propertyExpression: x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("[BIT]")
            .IsRequired();
    }
}
