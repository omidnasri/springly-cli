using System;
using System.Linq;
using TestScriptRunner;
using Xunit;

namespace TestScriptRunnerUnitTests
{
    public class TokenizerTests
    {
        [Fact]
        public void Parse_ForUseCommand_ReturnsExpectedTokens()
        {
            // Arrange
            var script = "use \"tour-platform.json\"";

            // Act
            var tokens = Lexer.Tokenize(script);

            // Assert
            Assert.Equal(3, tokens.Count());
            Assert.Equal(TokenType.Use, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(1).TokenType);
            Assert.Empty(tokens.ElementAt(1).Value);

            Assert.Equal(TokenType.StringValue, tokens.ElementAt(2).TokenType);
            Assert.Equal("tour-platform.json", tokens.ElementAt(2).Value);
        }

        [Fact]
        public void Parse_ForCheckWithColonCommand_ReturnsExpectedTokens()
        {
            // Arrange
            var script = "check \"luxary tours\", \"last second\" from \"tour-types\"";

            // Act
            var tokens = Lexer.Tokenize(script);

            // Assert
            Assert.Equal(10, tokens.Count());

            Assert.Equal(TokenType.Check, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(1).TokenType);
            Assert.Empty(tokens.ElementAt(1).Value);

            Assert.Equal(TokenType.StringValue, tokens.ElementAt(2).TokenType);
            Assert.Equal("luxary tours", tokens.ElementAt(2).Value);

            Assert.Equal(TokenType.Colon, tokens.ElementAt(3).TokenType);
            Assert.Empty(tokens.ElementAt(3).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(4).TokenType);
            Assert.Empty(tokens.ElementAt(4).Value);

            Assert.Equal(TokenType.StringValue, tokens.ElementAt(5).TokenType);
            Assert.Equal("last second", tokens.ElementAt(5).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(6).TokenType);
            Assert.Empty(tokens.ElementAt(6).Value);

            Assert.Equal(TokenType.From, tokens.ElementAt(7).TokenType);
            Assert.Empty(tokens.ElementAt(7).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(8).TokenType);
            Assert.Empty(tokens.ElementAt(8).Value);

            Assert.Equal(TokenType.StringValue, tokens.ElementAt(9).TokenType);
            Assert.Equal("tour-types", tokens.ElementAt(9).Value);
        }

        [Fact]
        public void Parse_ForValidScriptWithNewLineAtEnd_ReturnsExpectedTokens()
        {
            // Arrange
            var script = "use \"tour-platform.json\"\r\n";

            // Act
            var tokens = Lexer.Tokenize(script);

            // Assert
            Assert.Equal(4, tokens.Count());
            Assert.Equal(TokenType.Use, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.WhiteSpace, tokens.ElementAt(1).TokenType);
            Assert.Empty(tokens.ElementAt(1).Value);

            Assert.Equal(TokenType.StringValue, tokens.ElementAt(2).TokenType);
            Assert.Equal("tour-platform.json", tokens.ElementAt(2).Value);

            Assert.Equal(TokenType.NewLine, tokens.ElementAt(3).TokenType);
            Assert.Empty(tokens.ElementAt(3).Value);
        }
    }
}
