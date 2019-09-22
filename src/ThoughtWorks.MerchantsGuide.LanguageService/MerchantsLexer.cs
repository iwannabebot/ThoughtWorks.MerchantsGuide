using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ThoughtWorks.MerchantsGuide.LanguageService.Tokens;

namespace ThoughtWorks.MerchantsGuide.LanguageService
{
    public class MerchantsLexer : Behaviors.ILexer<string, Tokens.Token>
    {
        List<Tokens.Token> Tokens = new List<Tokens.Token>();
        public string Syntax { get; private set; }
        public readonly Regex separator = new Regex(
            @"[""'`{[\]}]?(how\s+(much|many)|\?|\.|\,|\n|\r\n|\w+)[""'`{[\]}]?", 
            RegexOptions.Compiled);

        public Tokens.Token[] Parse(string syntax)
        {
            this.Syntax = string.IsNullOrEmpty(syntax) ? string.Empty : syntax;
            var matches = separator.Matches(this.Syntax);
            for(int i = 0; i< matches.Count; i++)
            {
                Tokens.Add(Tokenize(matches[i].ToString()));
            }
            return Tokens.ToArray();
        }

        private Tokens.Token Tokenize(string match)
        {
            var clause = match.Trim('"', '\'', '`', '{', '}', '[', ']');
            if (new Regex(@"\?|\.|\,|\r\n|\n").IsMatch(clause))
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.Separator, clause);
            }
            else if (new Regex(@"how\s+(much|many)").IsMatch(clause) || new Regex(@"is").IsMatch(clause))
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.Operator, clause);
            }
            else if (new Regex(@"(\d+\.*\d*)|I|V|X|L|C|D|M").IsMatch(clause))
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.Literal, clause);
            }
            else if (new Regex(@"Credits?", RegexOptions.IgnoreCase).IsMatch(clause))
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.Literal, clause);
            }
            else if (new Regex(@"\w+").IsMatch(clause))
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.Identifier, clause);
            }
            else
            {
                return new Tokens.Token(LanguageService.Tokens.TokenType.None, string.Empty);
            }
        }
    }
}
