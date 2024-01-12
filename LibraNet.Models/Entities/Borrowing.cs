using LibraNet.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Models.Entities
{
    public class Borrowing
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowingFrom { get; set; }
        public DateTime BorrowingTo { get; set; }
        public BorrowingStatus Status { get; set; }

    }
}
