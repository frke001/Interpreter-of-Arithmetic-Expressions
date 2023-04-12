using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class Interpreter
    {
        private Dictionary<String,INode> table = new Dictionary<String, INode>();

        public int Evaluate(INode root)
        {
            if(root.GetType() == typeof(IdentifierNode))
            {
                IdentifierNode identifierNode = (IdentifierNode)root;
                table[identifierNode.identifier.GetSemanticValue()] = identifierNode.value;
                return EvaluateIdentifierNode((IdentifierNode)root);
            }
            else if(root.GetType() == typeof(KeyWordNode))
                return EvaluateKeyWordNode((KeyWordNode)root);
            else if(root.GetType() == typeof(BinOpNode))
                return EvaluateBinOpNode((BinOpNode)root);
            else if (root.GetType() == typeof(IntNode))
                return EvaluateIntNode((IntNode)root);
            else 
                return EvaluateUnaryOpNode((UnaryOpNode)root);
        }

        public int EvaluateIntNode(IntNode node)
        {
            return node.GetValue();
        }
        public int EvaluateBinOpNode(BinOpNode node)
        {
            int result = 0;
            int leftOperand = this.Evaluate(node.left);
            int rightOperand = this.Evaluate(node.right);
            if(node.operation.GetType() == "+")
                result = leftOperand + rightOperand;
            if (node.operation.GetType() == "-")
                result = leftOperand - rightOperand;
            if (node.operation.GetType() == "*")
                result = leftOperand * rightOperand;
            if (node.operation.GetType() == "/")
            {
                if (rightOperand == 0)
                    throw new DivideByZeroException("Dividing by zero!");
                result = leftOperand / rightOperand;
            }
            return result;
        }
        public int EvaluateUnaryOpNode(UnaryOpNode node)
        {
            int number = this.Evaluate(node.node);

            if (node.operation.GetType() == "-")
                number = number * (-1);
            return number;
        }
        public int EvaluateIdentifierNode(IdentifierNode node)
        {
            int result = Evaluate(node.value);
            //Console.Write(node.identifier.GetSemanticValue() + " = ");
            return result;
        }
        public int EvaluateKeyWordNode(KeyWordNode node)
        {
            if(node.identifier == null) // if only an expression
            {
                return Evaluate(node.expression);
            }
            if (!table.ContainsKey(node.identifier.GetSemanticValue()))
                throw new UnsupportedOperationException("Syntax error!");

            return Evaluate(table[node.identifier.GetSemanticValue()]);
            // we calculate an expression for this identifier
        }
    }
}
