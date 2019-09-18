using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ThoughtWorks.MerchantsGuide.Core.Parser
{
    public class ParserRules
    {
        public static Regex StatementRegex = new Regex(@"(.*?)is(.*?)", RegexOptions.IgnoreCase);
        public static Regex AssignmentRegex = new Regex(@"(glob prok)(Gold|Silver|) is 57800 Credits", RegexOptions.IgnoreCase);
    }
}
