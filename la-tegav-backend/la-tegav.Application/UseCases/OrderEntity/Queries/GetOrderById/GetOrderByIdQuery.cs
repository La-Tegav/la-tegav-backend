using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int Id { get; set; }
}
