using la_tegav.Application.Dtos;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.OrderEntity.Queries.GetAllIncomingPerMonth;

public class GetAllIncomingPerMonthHandler : IRequestHandler<GetAllIncomingPerMonthQuery, OrderIncomingDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllIncomingPerMonthHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderIncomingDto> Handle(GetAllIncomingPerMonthQuery request, CancellationToken cancellationToken)
    {
        List<Order> allOrders = await _orderRepository.GetAll(cancellationToken);

        Dictionary<int, decimal> monthlyTotals = new Dictionary<int, decimal>();

        foreach (var month in Enumerable.Range(1, 12))
        {
            monthlyTotals[month] = allOrders
                .Where(or => or.OrderDate.Month == month && or.OrderDate.Year == DateTime.Now.Year)
                .Sum(or => or.Total);
        }

        return new OrderIncomingDto
        {
            IncomingJan = monthlyTotals[1],
            IncomingFeb = monthlyTotals[2],
            IncomingMar = monthlyTotals[3],
            IncomingApr = monthlyTotals[4],
            IncomingMay = monthlyTotals[5],
            IncomingJun = monthlyTotals[6],
            IncomingJul = monthlyTotals[7],
            IncomingAug = monthlyTotals[8],
            IncomingSep = monthlyTotals[9],
            IncomingOct = monthlyTotals[10],
            IncomingNov = monthlyTotals[11],
            IncomingDec = monthlyTotals[12]
        };
    }

}
