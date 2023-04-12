using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class UnrecognizedTokenException : Exception
    {
        public UnrecognizedTokenException(String e) : base(e) { }
    }
}
