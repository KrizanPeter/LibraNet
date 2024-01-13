using LibraNet.Contracts;
using LibraNet.Models.Enums;
using System.Security.Principal;

namespace LibraNet.Domain.Entities
{
    public class Book : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public BookStatus? Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifyBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public virtual IEnumerable<Borrowing>? Borrowings { get; set; }

    }
}
