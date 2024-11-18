using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrderStatus;

public class GetAllOrderStatusQuery : IRequest<OrderStatusDto> { }
