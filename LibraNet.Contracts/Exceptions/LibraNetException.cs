using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Exceptions
{
    public class LibraNetException(string message, Exception? innerException) : Exception(message, innerException)
    {
    }
}
