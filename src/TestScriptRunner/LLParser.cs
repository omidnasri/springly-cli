using System;
using System.Collections.Generic;

namespace TestScriptRunner
{
    public class LLParser
    {
        public static object Parse(IEnumerable<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }

    public class TreeNode
    {
        public Token Token { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }
    }
}