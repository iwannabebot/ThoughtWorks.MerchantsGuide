using System;
using System.Collections.Generic;
using System.Text;
using ThoughtWorks.MerchantsGuide.LanguageService;

namespace ThoughtWorks.MerchantsGuide.App
{
    public static class MerchantsLanguageService
    {
        readonly static MerchantsLexer Lexer = new MerchantsLexer();
        readonly static MerchantsCompiler Compiler = new MerchantsCompiler();
        readonly static MerchantsInterpreter Interpreter = new MerchantsInterpreter();
        public static string Calculate(string input)
        {
            return Interpreter.Interpret(Compiler.Compile(Lexer.Parse(input)));
        }
    }
}
