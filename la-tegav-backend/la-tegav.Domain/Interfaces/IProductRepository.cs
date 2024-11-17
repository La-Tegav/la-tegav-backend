using la_tegav.Domain.Entities;

namespace la_tegav.Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product> 
{
    Task<List<Product>> GetProductsByIdsAsync(IEnumerable<int> productsIds, CancellationToken cancellationToken);
}
