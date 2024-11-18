using la_tegav.Application.Dtos;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllIncomingPerMonth;

public class GetAllIncomingPerMonthQuery : IRequest<OrderIncomingDto> { }