using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
