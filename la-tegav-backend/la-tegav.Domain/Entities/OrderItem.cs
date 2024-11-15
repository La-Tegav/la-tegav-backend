#nullable disable
using la_tegav.Domain.Common;

namespace la_tegav.Domain.Entities;

public class OrderItem : AuditableEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnityPrice { get; set; }

    private decimal _subtotal;
    public decimal Subtotal
    {
        get => Quantity * UnityPrice;
        set => _subtotal = value;
    }
}
