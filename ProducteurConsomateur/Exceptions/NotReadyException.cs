using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducteurConsomateur
{
    class NotReadyException : Exception
    {
        public NotReadyException()
        {
        }

        public NotReadyException(string message) : base(message)
        {
        }

        public NotReadyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
