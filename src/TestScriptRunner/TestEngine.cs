namespace TestScriptRunner
{
    public class TestEngine
    {
        public static ExecutionResult Execute(TestCaseSourceFile[] files)
        {
            foreach (var scriptFile in files)
            {
                var tokens = Lexer.Tokenize(scriptFile);

                var syntaxTree = LLParser.Parse(tokens);

                Evaluator.Eval(syntaxTree);
            }

            return new ExecutionResult();
        }
    }

    public class ExecutionResult
    {

    }
}
