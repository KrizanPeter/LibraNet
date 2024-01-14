using LibraNet.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.Contracts.Dtos.Book
{
    public class BookUpdateDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        public required string Author { get; set; }
    }
}
