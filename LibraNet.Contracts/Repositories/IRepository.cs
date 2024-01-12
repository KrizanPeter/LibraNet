using LibraNet.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
