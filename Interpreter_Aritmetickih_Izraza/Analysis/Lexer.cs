using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class Lexer
    {
        private String source;
        private int sourcePossition = 0;

        public Lexer(String input)
        {
            this.source = input;
        }

    
        public Token Next()
        {
            String number = "";
            String keyWord = "";

            while (sourcePossition < source.Length && char.IsWhiteSpace(source[sourcePossition]))
            {
                sourcePossition++;
            }
            if (sourcePossition == source.Length)
                return new Token("EOF");
            else if (sourcePossition > source.Length)
                throw new EOFException("Over Range!");
            if (char.IsDigit(source[sourcePossition]))
            {
                while (sourcePossition < source.Length && char.IsDigit(source[sourcePossition]))
                {
                    number += source[sourcePossition];
                    sourcePossition++;
                }
                return new Token("INT", number);
            }
            if (char.IsLetter(source[sourcePossition]))
            {
                while (sourcePossition < source.Length && char.IsLetter(source[sourcePossition]))
                {
                    keyWord += source[sourcePossition];
                    sourcePossition++;
                }
                if (keyWord.Equals("print"))
                    return new Token("KEYWORD", keyWord);
                else
                    return new Token("IDENTIFIER", keyWord);
            }
            if(source[sourcePossition] == '+')
            {
                sourcePossition++;
                return new Token("+");
            }
            if (source[sourcePossition] == '-')
            {
                sourcePossition++;
                return new Token("-");
            }
            if (source[sourcePossition] == '*')
            {
                sourcePossition++;
                return new Token("*");
            }
            if (source[sourcePossition] == '/')
            {
                sourcePossition++;
                return new Token("/");
            }
            if (source[sourcePossition] == '(')
            {
                sourcePossition++;
                return new Token("(");
            }
            if (source[sourcePossition] == ')')
            {
                sourcePossition++;
                return new Token(")");
            }
            if (source[sourcePossition] == '=')
            {
                sourcePossition++;
                return new Token("=");
            }
            if (source[sourcePossition] == ';')
            {
                sourcePossition++;
                return new Token(";");
            }
       
            throw new UnrecognizedTokenException("Lexical error!");
        }
    }
}
