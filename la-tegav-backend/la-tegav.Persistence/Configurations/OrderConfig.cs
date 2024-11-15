using la_tegav.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace la_tegav.Persistence.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("TB_Order");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Total)
            .HasColumnName("Total")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.Address)
            .HasColumnName("Address")
            .HasColumnType("[NVARCHAR](255)");

        builder.Property(x => x.OrderDate)
         .HasColumnName("OrderDate")
         .HasColumnType("[DATE]")
         .IsRequired();

        builder.Property(x => x.DeliveryDate)
         .HasColumnName("DeliveryDate")
         .HasColumnType("[DATE]");

        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey("OrderId") 
            .OnDelete(DeleteBehavior.Cascade);

    }
}
