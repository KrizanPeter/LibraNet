using LibraNet.Contracts;
using LibraNet.Domain.LibraContext;
using LibraNet.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraNet.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public readonly LibraDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(LibraDbContext db)
        {
            _db = db;
            dbSet = db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedBy = Guid.Empty;
            entity.LastModifyBy = Guid.Empty;
            entity.DateOfCreation = DateTime.Now;
            entity.DateOfLastModification = entity.DateOfCreation;
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> querry = dbSet;
            return await querry.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> querry = dbSet;

            if (filter != null)
            {
                querry = querry.Where(filter);
            }

            return await querry.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
