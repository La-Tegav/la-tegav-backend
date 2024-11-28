using la_tegav.Domain.Common;
using la_tegav.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace la_tegav.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        _context.Add(entity);
    }

    public async Task<T> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
    }

    public async Task BulkDelete(List<int> ids, CancellationToken cancellation)
    {
        var entities = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellation);

        if (entities.Any())
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellation);
        }
    }

    public async Task<List<T>> GetAllAsync2<TGetAll>(
        bool isAsNoTracking,
        Expression<Func<T, bool>>? filter = null, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default) where TGetAll : AuditableEntity
    {
        IQueryable<T> query = _context.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (isAsNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync(cancellationToken);
    }
}
