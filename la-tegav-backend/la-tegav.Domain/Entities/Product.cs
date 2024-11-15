#nullable disable
using la_tegav.Domain.Common;

namespace la_tegav.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Boolean Status { get; set; }
}
