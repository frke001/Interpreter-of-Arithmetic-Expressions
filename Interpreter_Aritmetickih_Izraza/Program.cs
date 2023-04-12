using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                string input = null;
                input = File.ReadAllText("./test.txt");
                Lexer lexer = new Lexer(input);
                Parser parser = new Parser(lexer);
                List<INode> list = parser.ExpressionList();
                Interpreter interpreter = new Interpreter();
                foreach (var el in list)
                {
                    int result = interpreter.Evaluate(el);
                    //if (el.GetType() == typeof(KeyWordNode))
                        Console.WriteLine(result);
                }
                Token t;
                /*while((t = lexer.Next()).GetType() != "EOF")
                {
                    Console.WriteLine(t);
                }*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
