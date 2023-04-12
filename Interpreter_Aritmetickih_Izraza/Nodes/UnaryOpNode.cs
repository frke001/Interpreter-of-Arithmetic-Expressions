using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class UnaryOpNode : INode
    {
        public Token operation;
        public INode node;

        public UnaryOpNode(Token operation, INode node)
        {
            this.operation = operation;
            this.node = node;
        }
    }
}
