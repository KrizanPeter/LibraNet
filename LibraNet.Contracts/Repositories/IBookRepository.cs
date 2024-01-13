using LibraNet.Contracts.Entities;
using LibraNet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Update(Book bookEntity);
    }
}
