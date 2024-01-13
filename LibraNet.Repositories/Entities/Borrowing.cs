using LibraNet.Contracts;
using LibraNet.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Domain.Entities
{
    public class Borrowing : IBaseEntity
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
        public virtual Book? Book { get; set; }


    }
}
