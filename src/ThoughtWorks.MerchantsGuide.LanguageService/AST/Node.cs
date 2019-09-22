using System;
using System.Collections.Generic;
using System.Text;

namespace ThoughtWorks.MerchantsGuide.LanguageService.AST
{
    public class Node
    {
        public NodeType NodeType { get; set; }
        public Tokens.Token[] Tokens { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<Tokens.Length; i++)
            {
                sb.Append(Tokens[i].ToString());
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
