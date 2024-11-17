using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetOrderById(request.Id, cancellationToken);

        if (order == null) throw new NullReferenceException();

        return OrderDto.ToDto(order);
    }
}
