using FluentAssertions;
using ReverseWords.Lib;

namespace ReverseWords.Tests;

public class ReverseWordsTests
{
    private readonly IReverseWordsStrategy[] strategies = [new DotNetBuiltInReverseWordsStrategy()];

    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("a good   example", "example good a")]
    public void ReverseWords_Returns_Expected_Result(string input, string reversed)
    {
        foreach (var strategy in strategies)
        {
            var lib = new ReverseWordsLib(strategy);

            lib.Run(input).Should().Be(reversed);
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ReverseWords_When_Input_Too_Short_Throws_Exception(string badInput)
    {
        foreach (var strategy in strategies)
        {
            var lib = new ReverseWordsLib(strategy);

            var badAct = () => lib.Run(badInput);

            badAct.Should()
                .Throw<ArgumentException>()
                .WithMessage("Input string cannot be null or whitespace only. (Parameter 'input')");
        }
    }

    [Fact]
    public void ReverseWords_When_Input_Too_Long_Throws_Exception()
    {
        var badInput = new string('a', (int)Math.Pow(10, 4) + 1);

        foreach (var strategy in strategies)
        {
            var lib = new ReverseWordsLib(strategy);

            var badAct = () => lib.Run(badInput);

            badAct.Should()
                .Throw<ArgumentException>()
                .WithMessage("Maximum length of input string is 10^4 characters. (Parameter 'input')");
        }
    }
}