using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Entities;
using LibraNet.Domain.LibraContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraNet.Domain.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(LibraDbContext db) : base(db)
        {
        }

    }
}
