using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order> ordersList = await _orderRepository.GetAllOrders(cancellationToken);

        return ordersList.Select(o => new OrderDto
        {
            Id = o.Id,
            Total = o.Total,
            Status = o.Status,
            Address = o.Address,
            DeliveryDate = o.DeliveryDate,
            OrderDate = o.OrderDate,
            Items = o.Items
        }).ToList();
    }
}
