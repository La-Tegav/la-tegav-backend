using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}
