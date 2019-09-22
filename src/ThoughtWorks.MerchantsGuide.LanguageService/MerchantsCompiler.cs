using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ThoughtWorks.MerchantsGuide.LanguageService.AST;
using ThoughtWorks.MerchantsGuide.LanguageService.Tokens;

namespace ThoughtWorks.MerchantsGuide.LanguageService
{
    public class MerchantsCompiler : Behaviors.ICompiler<Tokens.Token, AST.Node>
    {
        public AST.Node[] Compile(Tokens.Token[] tokens)
        {
            var nodes = new List<AST.Node>();
            if (tokens.Length > 0)
            {
                tokens = Hoist(tokens);
                var statements = tokens.ToList().TwSplit(token => token.Type == Tokens.TokenType.Separator);
                for(int i = 0; i< statements.Count; i++)
                {
                    nodes.Add(BuildNode(statements[i].ToArray()));
                }
            }
            return nodes.ToArray();
        }

        public Tokens.Token[] Hoist(Tokens.Token[] tokens)
        {
            var statements = tokens.ToList().TwSplit(token => token.Type == Tokens.TokenType.Separator);
            var hoistedTokens = new List<Tokens.Token[]>();
            var normalTokens = new List<Tokens.Token>();
            for (int i = 0; i< statements.Count; i++)
            {
                if (IsAssertion(statements[i].ToArray()))
                {
                    hoistedTokens.Add(statements[i].ToArray());   
                }
                else
                {
                    normalTokens.AddRange(statements[i].ToArray());
                }
            }
            for (int i = 0; i < hoistedTokens.Count; i++)
            {
                foreach (var token in normalTokens)
                {
                    if (token.Type == Tokens.TokenType.Identifier)
                    {
                        if (token.Value == statements[i][0].Value)
                        {
                            token.Type = Tokens.TokenType.Literal;
                            token.Value = statements[i][0].Value;
                        }
                    }
                }
            }
            return normalTokens.ToArray();
        }

        public AST.Node BuildNode(Tokens.Token[] tokens)
        {
            if (IsExpression(tokens))
            {
                return new AST.Node
                {
                    NodeType = NodeType.Expression,
                    Tokens = tokens
                };
            }
            else if (IsQuestion(tokens))
            {
                return new AST.Node
                {
                    NodeType = NodeType.Question,
                    Tokens = tokens
                };
            }
            else
            {
                return new AST.Node
                {
                    NodeType = NodeType.Unknown,
                    Tokens = tokens
                };
            }
        }

        public bool IsQuestion(Tokens.Token[] tokens)
        {
            var normalizedValue = string.Join(":", tokens.Select(t => t.Value)).Trim();
            var normalizedType = string.Join(":", tokens.Select(t => (int)t.Type)).Trim();

            if(new Regex(@"(how\s+(many|much)):(\w+:)?is:(\w+:)+\??").IsMatch(normalizedValue))
            {
                // how many Credits is glob prok Silver ?
                if (new Regex(@"3:5:3:(4:)+6").IsMatch(normalizedType))
                {
                    return true;
                }
                // how much is pish tegj glob glob ?
                if (new Regex(@"3:5:3:(4:)+6").IsMatch(normalizedType))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAssertion(Tokens.Token[] tokens)
        {
            var normalizedValue = string.Join(":", tokens.Select(t => t.Value)).Trim();
            var normalizedType = string.Join(":", tokens.Select(t => (int)t.Type)).Trim();

            if (new Regex(@"\w+:is:\w+").IsMatch(normalizedValue) 
                && new Regex(@"6:3:4").IsMatch(normalizedType))
            {
                if(tokens[2].Type == Tokens.TokenType.Literal)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsExpression(Tokens.Token[] tokens)
        {
            var normalizedValue = string.Join(":", tokens.Select(t => t.Value)).Trim();
            var normalizedType = string.Join(":", tokens.Select(t => (int)t.Type)).Trim();
            if (new Regex(@"(4:)+6:3:4:5").IsMatch(normalizedType))
            {
                return true;
            }
            return false;
        }
    }
}
