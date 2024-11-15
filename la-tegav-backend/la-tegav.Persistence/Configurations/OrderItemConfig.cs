using la_tegav.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace la_tegav.Persistence.Configurations;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("TB_OrderItem");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.ProductName)
            .HasColumnName("ProductName")
            .HasColumnType("[NVARCHAR](255)")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasColumnName("Quantity")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.UnityPrice)
            .HasColumnName(name: "UnityPrice")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Subtotal)
            .HasColumnName(name: "Subtotal")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne<Order>()
            .WithMany(o => o.Items)
            .HasForeignKey("OrderId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
