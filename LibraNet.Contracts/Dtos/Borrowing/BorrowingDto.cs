using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Borrowing
{
    public class BorrowingDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowingFrom { get; set; }
        public DateTime BorrowingTo { get; set; }
        public BorrowingStatus Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifyBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public BookDto? Book { get; set; }
    }
}
