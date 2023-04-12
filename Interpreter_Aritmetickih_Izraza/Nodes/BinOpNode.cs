using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class BinOpNode : INode
    {
        public INode left;
        public INode right;
        public Token operation;
        //public int operationValue;


        public BinOpNode(INode left, Token operation, INode right)
        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }

    }
}
