using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.CreateProduct;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    Boolean Status
) : IRequest<ProductDto>;
