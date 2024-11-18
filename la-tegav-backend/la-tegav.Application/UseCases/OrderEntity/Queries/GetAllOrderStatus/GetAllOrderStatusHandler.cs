using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Enums;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrderStatus;

public class GetAllOrderStatusHandler : IRequestHandler<GetAllOrderStatusQuery, OrderStatusDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrderStatusHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderStatusDto> Handle(GetAllOrderStatusQuery request, CancellationToken cancellationToken)
    {
        List<Order> allStatus = await _orderRepository.GetAll(cancellationToken);

        var result = new OrderStatusDto
        {
            TotalPending = allStatus.Count(order => order.Status == OrderStatus.Pending),
            TotalSent = allStatus.Count(order => order.Status == OrderStatus.Sent),
            TotalCompleted = allStatus.Count(order => order.Status == OrderStatus.Completed),
            TotalCanceled = allStatus.Count(order => order.Status == OrderStatus.Canceled)
        };

        return result;
    }
}
