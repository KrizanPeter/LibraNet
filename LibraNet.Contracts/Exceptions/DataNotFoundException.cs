using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Exceptions
{
    public class DataNotFoundException : LibraNetException
    {
        public DataNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public DataNotFoundException(string message) : base(message, null) { }

    }
}
