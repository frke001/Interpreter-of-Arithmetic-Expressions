using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Interpreter_Aritmetickih_Izraza;

namespace Interpreter_Aritmetickih_Izraza_Test
{
    public class ParserTest
    {

        [Test]
        public void ParserTest_ParsingTreeTest()
        {
            Lexer lexer = new Lexer("variable = (5 + 3) * 2; print(variable); 6 / 2; -254;");
            Parser parser = new Parser(lexer);
            List<INode> list = parser.ExpressionList();

            Assert.AreEqual(list[0].GetType(), typeof(IdentifierNode));
            Assert.AreEqual(list[1].GetType(), typeof(KeyWordNode));
            Assert.AreEqual(list[2].GetType(), typeof(BinOpNode));
            Assert.AreEqual(list[3].GetType(), typeof(UnaryOpNode));

        }

        [Test]

        public void ParserTest_ShouldThrowUnrecognizedTokenException()
        {
            Lexer lexer = new Lexer("b = (5 - 3) / 2");
            Parser parser = new Parser(lexer);
           

            Assert.Throws<UnrecognizedTokenException>(() => { parser.ExpressionList(); });
        }
    }
}
