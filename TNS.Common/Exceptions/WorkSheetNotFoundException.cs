using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.Exceptions
{
    public class WorkSheetNotFoundException : Exception
    {
        public WorkSheetNotFoundException()
        {
        }

        public WorkSheetNotFoundException(string message)
        : base(message)
        {
        }

        public WorkSheetNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
