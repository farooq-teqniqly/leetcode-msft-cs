using FluentAssertions;
using ReverseWords.Lib;

namespace ReverseWords.Tests;

public class InPlaceReverseWordsStrategyTests
{
    private readonly IReverseWordsStrategy strategy = new InPlaceReverseWordsStrategy();

    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("hello world", "world hello")]
    [InlineData("a good example", "example good a")]
    [InlineData("Bob Loves Alice", "Alice Loves Bob")]
    public void Strategy_Reverses_Words(string input, string reversed)
    {
        strategy.Run(input).Should().Be(reversed);
    }
}