using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.Tokens
{
    public enum TokenType
    {
        None = 0, // default to an unparsed token
        Whitespace = 1, // \t \s
        Separator = 2, // ? \r\n \n, . ,
        Operator = 3, // is, how much, how many
        Literal = 4, // 1, 2, 1.01, (I V X L C V D M)
        Currency = 5, // Credits, $, INR
        Identifier = 6, // anything that is not a keyword
    
    }
}
