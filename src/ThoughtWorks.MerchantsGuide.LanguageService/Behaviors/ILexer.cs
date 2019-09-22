using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Behaviors
{
    public interface ILexer<TInput, TToken> where TToken : Tokens.Token
    {
        TToken[] Parse(TInput syntax);
    }
}
