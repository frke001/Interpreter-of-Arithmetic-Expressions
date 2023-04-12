using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class Parser
    {
        private Dictionary<String, INode> table = new(); 
        private Lexer lexer;
        private Token currToken;

        private void Next()
        {
            currToken = lexer.Next();
        }

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            Next();
        }

        public List<INode> ExpressionList()
        {
            List<INode> expressions = new List<INode>();
            while (currToken.GetType() != "EOF")
            {
                expressions.Add(MainExpression());
                if (currToken.GetType() != ";")
                    throw new UnrecognizedTokenException("Syntax error");
                Next();
            }
            return expressions;
        }
        public INode MainExpression()
        {
            if (currToken.GetType() == "IDENTIFIER")
            {
                Token identifier = currToken;
                Next();
                if (currToken.GetType() == "=")
                {
                    Next();
                    INode exp = this.Expression();
                    table[identifier.GetSemanticValue()] = exp;
                    return new IdentifierNode(exp, identifier);
                }
                else
                {
                    if (!table.ContainsKey(identifier.GetSemanticValue()))
                        throw new UnrecognizedTokenException("Syntax error!");
                    INode left = table[identifier.GetSemanticValue()];
                    Token operation = currToken;
                    Next();
                    INode right = this.Expression();
                    return new BinOpNode(left,operation,right);
                }
            }
            else if (currToken.GetType() == "KEYWORD")
            {
                Token identifier = currToken;
                Next();
                if (currToken.GetType() != "(")
                    throw new UnrecognizedTokenException("Syntax error!");
                Next();
                INode expression = this.Expression();
                if (currToken.GetType() != ")")
                    throw new UnrecognizedTokenException("Syntax error!");
                Next();
                if (expression.GetType() == typeof(IdentifierNode))
                    return new KeyWordNode(identifier);
                return new KeyWordNode(null, expression); // if we print only the value of the expression
            }
            else
                return this.Expression();

        }
        public INode Expression()
        {
            INode left = this.Term();

            while (currToken.GetType().Equals("+") || currToken.GetType().Equals("-"))
            {
                Token operation = currToken;
                Next();
                INode right = this.Term();
                left = new BinOpNode(left, operation, right); // assign to the left node if there were more + or -
            }
            return left;
        }
   
        public INode Term()
        {
            INode left = this.Factor();

            while(currToken.GetType().Equals("*") || currToken.GetType().Equals("/")) 
            {
                Token operation = currToken;
                Next();
                INode right = this.Factor();
                left = new BinOpNode(left,operation,right); // assign to the left node if there were more * or /
            }
            return left;
        }
        public INode Factor()
        {
            if (currToken.GetType() == "-" || currToken.GetType() == "+")
            {
                Token operation = currToken;
                Next();
                INode factor = this.Factor();
                return new UnaryOpNode(operation, factor);
            }
            if (currToken.GetType() == "INT")
            {
            INode intNode = new IntNode(int.Parse(currToken.GetSemanticValue()));
            Next();
            return intNode;
            }
            if (currToken.GetType() == "(")
            {
                Next();
                INode expression = this.Expression();
                if (currToken.GetType() == ")")
                {
                    Next();
                    return expression;
                }
            }
            if(currToken.GetType() == "IDENTIFIER")
            {
                if (!table.ContainsKey(currToken.GetSemanticValue()))
                    throw new UnsupportedOperationException("Syntax error!");
                INode exp = table[currToken.GetSemanticValue()];
                Next();
                return exp;
            }
            throw new UnrecognizedTokenException("Syntax error!");
        }

    }
}
