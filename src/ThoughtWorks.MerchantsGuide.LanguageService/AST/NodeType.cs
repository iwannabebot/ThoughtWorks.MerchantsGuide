using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.AST
{
    public enum NodeType
    {
        Assertion,
        Expression,
        Evaluation,
        Question,
        Answer,
        Unknown
    }
}
