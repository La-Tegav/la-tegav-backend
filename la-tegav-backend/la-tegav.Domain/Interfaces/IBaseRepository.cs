using la_tegav.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace la_tegav.Domain.Interfaces;

public interface IBaseRepository<T> where T : AuditableEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
    Task BulkDelete(List<int> ids, CancellationToken cancellation);
    //Task<List<T>> GetAll2(CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync2<TGetAll>(bool isAsNoTracking, Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default) where TGetAll : AuditableEntity;
}
