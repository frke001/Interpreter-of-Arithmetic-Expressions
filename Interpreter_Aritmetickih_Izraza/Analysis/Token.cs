using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Aritmetickih_Izraza
{
    public class Token
    {
        private string Type;
        private string SemanticValue;

        public Token(string type, string? semanticValue = null)
        {
            this.Type = type;
            this.SemanticValue = semanticValue;
        }

        public string GetType()
        {
            return Type;
        }
        public string GetSemanticValue() 
        {
            return SemanticValue;
        }

        public override string ToString()
        {
            if(this.SemanticValue == null)
                return this.Type;
            return this.Type + ":" + this.SemanticValue;
        }
    }
}
