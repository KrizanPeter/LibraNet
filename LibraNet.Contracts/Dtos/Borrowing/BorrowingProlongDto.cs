

using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Borrowing
{
    public class BorrowingProlongDto
    {
        public Guid Id { get; set; }
        public DateTime BorrowingTo { get; set; }
    }
}
