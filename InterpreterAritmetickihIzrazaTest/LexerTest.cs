using NUnit.Framework;
using Interpreter_Aritmetickih_Izraza;
namespace Interpreter_Aritmetickih_Izraza_Test
{
    public class Lexertest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLexer_MultipeOperationAndPrintTest()
        {
            Lexer lexer = new Lexer("a = 25 * (3 + 7) - 3; print(a);");
            Token t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,t15,t16,t17,t18;
            t1 = lexer.Next();
            t2 = lexer.Next();
            t3 = lexer.Next();
            t4 = lexer.Next();
            t5 = lexer.Next();
            t6 = lexer.Next();
            t7 = lexer.Next();
            t8 = lexer.Next();
            t9 = lexer.Next();
            t10 = lexer.Next();
            t11 = lexer.Next();
            t12 = lexer.Next();
            t13 = lexer.Next();
            t14 = lexer.Next();
            t15 = lexer.Next();
            t16 = lexer.Next();
            t17 = lexer.Next();

            Assert.AreEqual("IDENTIFIER", t1.GetType());
            Assert.AreEqual(t1.GetSemanticValue(), "a");
            Assert.AreEqual(t2.GetType(), "=");
            Assert.AreEqual(t3.GetType(), "INT");
            Assert.AreEqual(t3.GetSemanticValue(), "25");
            Assert.AreEqual(t4.GetType(), "*");
            Assert.AreEqual(t5.GetType(), "(");
            Assert.AreEqual(t6.GetType(), "INT");
            Assert.AreEqual(t6.GetSemanticValue(), "3");
            Assert.AreEqual(t7.GetType(), "+");
            Assert.AreEqual(t8.GetType(), "INT");
            Assert.AreEqual(t8.GetSemanticValue(), "7");
            Assert.AreEqual(t9.GetType(), ")");
            Assert.AreEqual(t10.GetType(), "-");
            Assert.AreEqual(t11.GetType(), "INT");
            Assert.AreEqual(t11.GetSemanticValue(), "3");
            Assert.AreEqual(t12.GetType(), ";");
            Assert.AreEqual(t13.GetType(), "KEYWORD");
            Assert.AreEqual(t13.GetSemanticValue(), "print");
            Assert.AreEqual(t14.GetType(), "(");
            Assert.AreEqual(t15.GetType(), "IDENTIFIER");
            Assert.AreEqual(t15.GetSemanticValue(), "a");
            Assert.AreEqual(t16.GetType(), ")");
            Assert.AreEqual(t17.GetType(), ";");

        }

        [Test]
        public void Lexertest_ShouldThrowUnrecognizedTokenException()
        {
            Lexer lexer = new Lexer("print(@);");
            lexer.Next();
            lexer.Next();

            Assert.Throws<UnrecognizedTokenException>(() => { lexer.Next(); }); 
        }
    }
}