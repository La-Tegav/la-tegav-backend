using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;

namespace la_tegav.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }
}
