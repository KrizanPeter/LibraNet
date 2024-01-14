using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifyBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public IEnumerable<BorrowingDto>? Borrowings { get; set; }
    }
}
