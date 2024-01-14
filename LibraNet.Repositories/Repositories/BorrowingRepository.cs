using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Entities;
using LibraNet.Domain.LibraContext;
using System.Linq.Expressions;
using LibraNet.Repositories;


namespace LibraNet.Domain.Repositories
{
    public class BorrowingRepository : Repository<Borrowing>, IBorrowingRepository
    {

        public BorrowingRepository(LibraDbContext db) : base(db)
        {
        }

     
    }
}
