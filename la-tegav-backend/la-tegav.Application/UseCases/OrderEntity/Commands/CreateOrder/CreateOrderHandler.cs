using FluentValidation;
using FluentValidation.Results;
using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Enums;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Commands.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, OrderDto>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public CreateOrderHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, 
        IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<OrderDto> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        CreateOrderValidator validator = new CreateOrderValidator();
        ValidationResult validatorResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);

        List<int> productsIds = request.Products
            .Select(p => p.ProductId)
            .ToList();

        List<Product> products = await _productRepository
            .GetProductsByIdsAsync(productsIds, cancellationToken);

        if (products.Count < productsIds.Count)
        {
            throw new Exception("Um ou mais produtos não foram encontrados ou estão inativos.");
        }

        List<OrderItem> orderItems = request.Products.Select(p =>
        {
    
            Product? product = products
                .FirstOrDefault(prod => prod.Id == p.ProductId);

            return new OrderItem
            {
                ProductId = product!.Id,
                ProductName = product.Name,
                Quantity = p.Quantity,
                UnityPrice = product.Price,
                Subtotal = p.Quantity * product.Price
            };
        }).ToList();

        decimal total = orderItems.Sum(x => x.Subtotal);

        Order order = new Order
        {
            Total = total,
            Status = OrderStatus.Pending,
            Address = request.Address,
            OrderDate = request.OrderDate,
            DeletedDate = request.DeliveryDate,
            Items = orderItems
        };

        _orderRepository.Create(order);
        await _unitOfWork.Commit(cancellationToken);

        return OrderDto.ToDto(order);
    }
}
