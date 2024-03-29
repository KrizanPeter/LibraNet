﻿using LibraNet.Contracts;
using LibraNet.Contracts.Enums;

namespace LibraNet.Contracts.Entities
{
    public class Book : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifyBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public virtual IEnumerable<Borrowing>? Borrowings { get; set; }

    }
}
