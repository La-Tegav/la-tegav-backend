#nullable disable
using la_tegav.Domain.Entities;
using la_tegav.Domain.Enums;

namespace la_tegav.Application.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public OrderStatus Status { get; set; }
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<OrderItem> Items { get; set; }

    public static OrderDto ToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            Total = order.Total,
            Status = order.Status,
            Address = order.Address,
            DeliveryDate = order.DeliveryDate,
            OrderDate = order.OrderDate,
            Items = order.Items
        };
    }
}
