using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;

namespace la_tegav.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }
}
