using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetById(request.Id, cancellationToken);

        if (product == null) throw new NullReferenceException();

        return ProductDto.ToDto(product);
    }
}
