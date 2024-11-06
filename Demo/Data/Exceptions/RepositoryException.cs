using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message): base(message) { }
    }
}
