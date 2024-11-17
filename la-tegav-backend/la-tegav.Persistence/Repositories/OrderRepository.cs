using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace la_tegav.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    public async Task<List<Order>> GetAllOrders(CancellationToken cancellationToken)
    {
        return await _context.Orders
            .Include(oi => oi.Items)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
    {
        return await _context.Orders
            .Include(oi => oi.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
