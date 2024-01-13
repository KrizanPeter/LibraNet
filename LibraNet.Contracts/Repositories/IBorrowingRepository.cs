using LibraNet.Contracts.Entities;
using LibraNet.Repositories;


namespace LibraNet.Contracts.Repositories
{
    public interface IBorrowingRepository : IRepository<Borrowing>
    {
        Borrowing Update(Borrowing bookEntity); 
    }
}
