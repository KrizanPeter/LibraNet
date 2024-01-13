using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Book
{
    public class BookUpdateDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public BookStatus? Status { get; set; }
    }
}
