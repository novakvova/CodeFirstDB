using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestException
{
    public class ExceptionWpf : Exception
    {
        public ExceptionWpf()
        {

        }
        public ExceptionWpf(string text): base(text)
        {

        }
    }
}
