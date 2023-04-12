using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Interpreter_Aritmetickih_Izraza;

namespace Interpreter_Aritmetickih_Izraza_Test
{
    public class InterpreterTest
    {
        [Test]

        public void InterpreterTest_ParsinTreeEvaluation()
        {
            String input = null;
            input = " 5 + 4; a = 25 * 3 + 7 + 2 * -1 + 5; b = 52 - 25 - 1; 25; " +
                "print(a);c = (((a))) + (-3 + b * (b +a)) / 2;" +
                "print(b); print(c);";
            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);
            List<INode> list = parser.ExpressionList();
            Interpreter interpreter = new Interpreter();
            Assert.AreEqual(interpreter.Evaluate(list[0]), 9);
            Assert.AreEqual(interpreter.Evaluate(list[1]), 85);
            Assert.AreEqual(interpreter.Evaluate(list[2]), 26);
            Assert.AreEqual(interpreter.Evaluate(list[3]), 25);
            Assert.AreEqual(interpreter.Evaluate(list[4]), 85);
            Assert.AreEqual(interpreter.Evaluate(list[5]), 1526);
            Assert.AreEqual(interpreter.Evaluate(list[6]), 26);
            Assert.AreEqual(interpreter.Evaluate(list[7]), 1526);
            foreach (var el in list)
            {
                int result = interpreter.Evaluate(el);
                //if (el.GetType() == typeof(KeyWordNode))
                    Console.WriteLine(result);
            }
        }
    }
}
