using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class KeyWordNode :  INode
    {
        public Token identifier;
        public INode expression;

        public KeyWordNode(Token? identifier = null,INode? expression = null)
        {
            this.identifier = identifier;
            this.expression = expression;
        }
    }
}
