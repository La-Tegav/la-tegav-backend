using la_tegav.Domain.Common;

namespace la_tegav.Domain.Interfaces;

public interface IBaseRepository<T> where T : AuditableEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
    Task BulkDelete(List<int> ids, CancellationToken cancellation);
}
