using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ThoughtWorks.MerchantsGuide.LanguageService;

namespace ThoughtWorks.MerchantsGuide.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = MerchantsConsole.ArgumentsParser(args);
            if (!input.ContainsKey("syntax") || input["syntax"] == null)
            {
                MerchantsConsole.Error(
                    $"Fatal error: Need input file",
                    $"Usage:",
                    $"Syntax:     --[file|f]=<filepath>",
                    $"Examples:",
                    $"            --file=<file path>");
                MerchantsConsole.YesNo($"", $"Press any key to exit");
            }
            else
            {
                MerchantsConsole.WriteLine(
                    MerchantsLanguageService.Calculate(input["syntax"].ToString()));
            }
        }
    }
}
