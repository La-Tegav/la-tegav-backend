using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<List<OrderDto>> { }
