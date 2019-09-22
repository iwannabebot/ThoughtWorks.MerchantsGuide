using System;
using System.Collections.Generic;
using System.Text;
using ThoughtWorks.MerchantsGuide.LanguageService.AST;
using ThoughtWorks.MerchantsGuide.LanguageService.Exceptions;

namespace ThoughtWorks.MerchantsGuide.LanguageService
{
    public class MerchantsInterpreter : Behaviors.IInterpreter<AST.Node, string>
    {
        public string Interpret(AST.Node[] nodes)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < nodes.Length; i++)
            {
                try
                {
                    if (nodes[i].NodeType == NodeType.Expression)
                    {
                        var errorIfAny = CalculateExpression(nodes[i]);
                        if (errorIfAny.ToString().Trim().Length != 0)
                            output.AppendLine();
                    }
                    else if (nodes[i].NodeType == NodeType.Question)
                    {
                        output.AppendLine(CalculateAnswer(nodes[i]).ToString());
                    }
                }
                catch(InvalidSyntaxException exc)
                {
                    output.AppendLine(exc.Message);
                }
            }
            return output.ToString();
        }

        public AST.Node CalculateExpression(AST.Node expressionNode)
        {
            List<Tokens.Token> tokens = new List<Tokens.Token>();
            //pish tegj glob glob is 42
            //glob prok Silver is 68 Credits
            //glob prok Gold is 57800 Credits
            //glob prok Iron is 782 Credits
            try
            {

                return new AST.Node()
                {
                    NodeType = NodeType.Evaluation,
                    Tokens = tokens.ToArray()
                };
            }
            catch
            {
                tokens.Add(new Tokens.Token(Tokens.TokenType.None, "Error in understanding this"));
                return new AST.Node()
                {
                    NodeType = NodeType.Evaluation,
                    Tokens = tokens.ToArray()
                };
            }

        }

        public AST.Node CalculateAnswer(AST.Node questionNode)
        {
            List<Tokens.Token> tokens = new List<Tokens.Token>();
            // how much is pish tegj glob glob ?
            // how many Credits is glob prok Silver ? 
            try
            {
                return new AST.Node()
                {
                    NodeType = NodeType.Answer,
                    Tokens = tokens.ToArray()
                };
            }
            catch
            {
                throw new InvalidSyntaxException("I have no idea what you are talking about");
            }
        }
    }
}