#nullable disable
using la_tegav.Domain.Common;
using la_tegav.Domain.Enums;

namespace la_tegav.Domain.Entities;

public class Order : AuditableEntity
{
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<OrderItem> Items { get; set; }
}
