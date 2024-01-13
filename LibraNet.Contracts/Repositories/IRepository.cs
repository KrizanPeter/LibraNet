using LibraNet.Contracts.Entities;
using System.Linq.Expressions;

namespace LibraNet.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task AddAsync(T entity);
        void Remove(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null);
        void SaveChanges();
    }
}
