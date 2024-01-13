using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Entities;
using LibraNet.Domain.LibraContext;


namespace LibraNet.Domain.Repositories
{
    public class BorrowingRepository : Repository<Book>, IBorrowingRepository
    {

        public BorrowingRepository(LibraDbContext db) : base(db)
        {
        }

        public Borrowing Update(Borrowing bookEntity)
        {
            throw new NotImplementedException();
        }
    }
}
