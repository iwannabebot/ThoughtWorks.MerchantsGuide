using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Behaviors
{
    public interface ICompiler<TToken, TAstNode> 
        where TAstNode : AST.Node
        where TToken : Tokens.Token
    {
        TAstNode[] Compile(TToken[] tokens);

        TToken[] Hoist(TToken[] tokens);

        TAstNode BuildNode(TToken[] tokens);
    }
}
