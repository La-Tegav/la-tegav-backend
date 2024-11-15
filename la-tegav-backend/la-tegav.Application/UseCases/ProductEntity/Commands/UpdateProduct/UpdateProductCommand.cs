#nullable disable
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Boolean Status { get; set; }
}
