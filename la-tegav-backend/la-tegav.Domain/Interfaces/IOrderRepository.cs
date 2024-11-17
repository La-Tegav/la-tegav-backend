using la_tegav.Domain.Entities;

namespace la_tegav.Domain.Interfaces;

public interface IOrderRepository : IBaseRepository<Order> 
{
    Task<List<Order>> GetAllOrders(CancellationToken cancellationToken);
    Task<Order> GetOrderById(int id, CancellationToken cancellationToken);
}
