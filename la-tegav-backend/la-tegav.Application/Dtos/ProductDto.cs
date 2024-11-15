#nullable disable
using la_tegav.Domain.Entities;

namespace la_tegav.Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Boolean Status { get; set; }

    public static ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Status = product.Status
        };
    }
}
