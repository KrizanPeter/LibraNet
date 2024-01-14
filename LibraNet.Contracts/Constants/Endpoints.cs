using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Constants
{
    public static class Endpoints
    {
        
        public const string BookCreate = "/api/book/create";
        public const string BookUpdate = "/api/book/update";
        public const string BookDelete = "/api/book/delete";
        public const string BookGet = "/api/book/get";

        public const string BorrowingCreate = "/api/borrowing/create";
        public const string BorrowingProlong = "/api/borrowing/prolong";
        public const string BorrowingClose = "/api/borrowing/close";
        public const string BorrowingGet = "/api/bborrowingook/get";
    }
}
