using LibraNet.Models.Enums;

namespace LibraNet.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public BookStatus? Status { get; set; }

    }
}
