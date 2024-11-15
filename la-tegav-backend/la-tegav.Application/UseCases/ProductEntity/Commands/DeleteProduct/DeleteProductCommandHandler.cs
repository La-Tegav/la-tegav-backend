using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository
            .GetById(request.Id, cancellationToken);
        
        if (productToDelete == null) throw new NullReferenceException();


        _productRepository.Delete(productToDelete);

        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
