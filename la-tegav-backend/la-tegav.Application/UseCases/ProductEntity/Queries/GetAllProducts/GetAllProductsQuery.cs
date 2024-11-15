using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductDto>> { }
