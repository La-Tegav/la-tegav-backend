using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace la_tegav.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<List<Product>> GetProductsByIdsAsync(IEnumerable<int> productsIds, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(p => productsIds.Contains(p.Id) && p.Status)
            .ToListAsync(cancellationToken);
    }
}
