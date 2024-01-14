using LibraNet.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraNet.Contracts.Dtos.Borrowing
{
    public class BorrowingCreateDto
    {
        
        [Required(ErrorMessage = "The BookId field is required.")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "The BorrowingFrom field is required.")]
        public DateTime BorrowingFrom { get; set; }

        [Required(ErrorMessage = "The BorrowingTo field is required.")]
        public DateTime BorrowingTo { get; set; }
    }
}
