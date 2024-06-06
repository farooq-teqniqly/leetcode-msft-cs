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
    public void Reverse_Words_Returns_Expected_Result(string input, string reversed)
    {
        foreach (var strategy in strategies)
        {
            var lib = new ReverseWordsLib(strategy);

            lib.Run(input).Should().Be(reversed);
        }
    }
}