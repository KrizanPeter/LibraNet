using LibraNet.Contracts.Entities;


namespace LibraNet.Contracts.Repositories
{
    public interface IBorrowingRepository
    {
        Borrowing Update(Borrowing bookEntity); 
    }
}
