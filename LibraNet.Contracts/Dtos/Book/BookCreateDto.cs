
using LibraNet.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.Contracts.Dtos.Book
{
    public class BookCreateDto
    {
        [Required(ErrorMessage = "The Title field is required.")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "The Author field is required.")]
        public string? Author { get; set; }
        public BookStatus Status { get; set; } = BookStatus.New;
    }
}
