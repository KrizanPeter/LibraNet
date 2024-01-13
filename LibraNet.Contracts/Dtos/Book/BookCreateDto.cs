
using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Dtos.Book
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public BookStatus? Status { get; set; }
    }
}
