using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class IdentifierNode : INode
    {
        public INode value;
        public Token identifier;


        public IdentifierNode(INode value,Token identifier)
        {
           this.value = value;
            this.identifier = identifier;
        }
    }
}
