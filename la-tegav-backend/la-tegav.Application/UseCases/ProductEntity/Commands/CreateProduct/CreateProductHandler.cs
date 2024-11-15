using FluentValidation;
using la_tegav.Application.Dtos;
using la_tegav.Domain.Interfaces;
using la_tegav.Domain.Entities;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, ProductDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductValidator();
        var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Status = request.Status,
        };

        _productRepository.Create(product);
        await _unitOfWork.Commit(cancellationToken);

        return ProductDto.ToDto(product);
    }
}
