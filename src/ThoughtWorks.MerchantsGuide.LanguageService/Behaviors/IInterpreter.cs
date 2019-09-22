using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Behaviors
{
    public interface IInterpreter<TAstNode, TOutput> where TAstNode : AST.Node
    {
        TOutput Interpret(TAstNode[] nodes);
        AST.Node CalculateExpression(TAstNode expressionNode);
        AST.Node CalculateAnswer(TAstNode questionNode);
    }
}
