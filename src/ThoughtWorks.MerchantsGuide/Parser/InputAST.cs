using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ThoughtWorks.MerchantsGuide.Core.Parser
{
    // Input Abstract Syntax Tree
    // glob is I
    // prok is V
    // tegj is L
    // glob glob Silver is 34 Credits
    // glob prok Gold is 57800 Credits
    // pish pish Iron is 3910 Credits
    // how much is pish tegj glob glob ?
    // how many Credits is glob prok Silver ?
    // how many Credits is glob prok Gold ?
    // how many Credits is glob prok Iron ?
    // how much wood could a woodchuck chuck if a woodchuck could chuck wood ?
    // =============================================================
    // glob is I | glob prok Gold is 57800 Credits
    //    is                     is
    //   /  \                   /  \
    // glob  I   glob glob Silver   34 credits
    // =============================================================
    // how much is pish tegj glob glob ?
    //           is
    //          /  \
    //   how much   pish tegj glob glob ?
    // =============================================================
    // how many Credits is glob prok Silver ?
    //                   is
    //                /     \
    //   how many Credits   glob prok Silver ?
    // =============================================================
    // how much wood could a woodchuck chuck if a woodchuck could chuck wood ?
    // =============================================================
    public abstract class ASTNode
    {
        public string Syntax { get; set; }
        public virtual Regex Matcher { get; }
        public virtual bool Valid { get { return Syntax != null && Matcher.IsMatch(Syntax); } }
        public ASTNode(string syntax)
        {
            Syntax = syntax;
        }
        public virtual void BuildChildrens() { }
    }
    public abstract class InputASTNode : ASTNode
    {
        public InputASTNode Left { get; set; }
        public InputASTNode Right { get; set; }
        public override bool Valid
        {
            get
            {
                return base.Valid && (Left == null || Left.Valid) && (Right == null || Right.Valid);
            }
        }
        public InputASTNode(string syntax): base(syntax)
        {
            if (base.Valid)
            {
                BuildChildrens();
            }
        }
    }
    public class InputASTStatement : InputASTNode
    {
        public override Regex Matcher { get => ParserRules.StatementRegex; }

        public InputASTStatement(string syntax) : base(syntax) {}
        public override void BuildChildrens()
        {

        }
    }
}
