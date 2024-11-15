using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = await _productRepository
            .GetById(request.Id, cancellationToken);

        if (productToUpdate == null) throw new NullReferenceException();

        productToUpdate.Name = request.Name;
        productToUpdate.Description = request.Description;
        productToUpdate.Price = request.Price;
        productToUpdate.Description = request.Description;
        productToUpdate.Status = request.Status;

        _productRepository.Update(productToUpdate);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
