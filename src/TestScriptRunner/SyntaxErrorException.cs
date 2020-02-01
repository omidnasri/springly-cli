using System;
using System.Linq;

namespace TestScriptRunner
{
    public class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(int index, int line, string source, string fileName) : base($"Invalid syntax at column {index} line {line}: {FromSource(source, line)} in '{fileName}'")
        {
        }

        private static string FromSource(string source, int line)
        {
            var errorLineContent = source?.Split('\n')?.Skip(line + 1)?.FirstOrDefault();
            return errorLineContent?.Trim();
        }
    }
}