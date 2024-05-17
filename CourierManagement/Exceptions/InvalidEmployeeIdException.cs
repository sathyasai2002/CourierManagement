using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Exceptions
{
    internal class InvalidEmployeeIdException : ApplicationException
    {
        public InvalidEmployeeIdException(string msg) : base(msg) { }
    }
}
