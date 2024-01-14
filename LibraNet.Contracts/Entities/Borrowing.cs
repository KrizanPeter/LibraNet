using LibraNet.Contracts;
using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Entities
{
    public class Borrowing : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowingFrom { get; set; }
        public DateTime BorrowingTo { get; set; }
        public DateTime ClosedAt { get; set; }
        public BorrowingStatus Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifyBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public virtual Book? Book { get; set; }


    }
}
