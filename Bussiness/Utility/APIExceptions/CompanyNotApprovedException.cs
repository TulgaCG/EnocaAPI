using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Utility.APIExceptions
{
    public class CompanyNotApprovedException : Exception
    {
        public CompanyNotApprovedException() { }
        public CompanyNotApprovedException(string message) : base(message) { }
    }
}
