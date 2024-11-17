using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Commands.CreateOrder;
public sealed record CreateOrderRequest(
    string Address,
    DateTime OrderDate,
    DateTime DeliveryDate,
    List<ProductOrderDto> Products
) : IRequest<OrderDto>;

