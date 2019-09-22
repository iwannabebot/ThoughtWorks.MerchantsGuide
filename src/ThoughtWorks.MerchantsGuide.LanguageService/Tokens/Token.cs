using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Tokens
{
    public class Token
    {
        public TokenType Type { get; internal set; }
        public string Value { get; internal set; }

        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        internal static Token None()
        {
            return new Token(TokenType.None, "");
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
