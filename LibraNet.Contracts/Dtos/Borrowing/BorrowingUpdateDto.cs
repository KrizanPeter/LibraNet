

using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Borrowing
{
    public class BorrowingUpdateDto
    {
        public Guid BookId { get; set; }
        public DateTime BorrowingFrom { get; set; }
        public DateTime BorrowingTo { get; set; }
        public BorrowingStatus Status { get; set; }
    }
}
