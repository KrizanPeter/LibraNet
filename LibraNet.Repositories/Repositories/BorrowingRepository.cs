using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Entities;
using LibraNet.Domain.LibraContext;
using System.Linq.Expressions;
using LibraNet.Repositories;


namespace LibraNet.Domain.Repositories
{
    public class BorrowingRepository : Repository<Book>, IBorrowingRepository
    {

        public BorrowingRepository(LibraDbContext db) : base(db)
        {
        }

        public Task AddAsync(Borrowing entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Borrowing> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Borrowing> GetFirstOrDefaultAsync(Expression<Func<Borrowing, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Borrowing entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Borrowing> entities)
        {
            throw new NotImplementedException();
        }

        public Borrowing Update(Borrowing bookEntity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Borrowing>> IRepository<Borrowing>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
