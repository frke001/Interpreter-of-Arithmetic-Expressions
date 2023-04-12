using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class IntNode : INode
    {
        private int intValue;

        public IntNode(int value)
        {
            this.intValue = value;
        }
        public int GetValue()
        {
            return intValue;
        }
    }
}
