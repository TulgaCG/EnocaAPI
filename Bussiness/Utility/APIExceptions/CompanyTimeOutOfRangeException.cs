using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Utility.APIExceptions
{
    public class CompanyTimeOutOfRangeException : Exception
    {
        public CompanyTimeOutOfRangeException() { }
        public CompanyTimeOutOfRangeException(string message) : base(message) { }
    }
}
