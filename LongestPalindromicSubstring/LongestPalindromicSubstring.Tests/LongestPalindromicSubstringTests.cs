using System.Linq.Expressions;
using FluentAssertions;
using LongestPalindromicSubstring.Lib;

namespace LongestPalindromicSubstring.Tests;

public class LongestPalindromicSubstringTests
{
    private ILongestPalindromicSubstringStrategy[] strategies =
    [
        new LongestPalindromicSubstringNSquaredStrategy()
    ];

    [Theory]
    [InlineData("abbc", "bb")]
    [InlineData("babad", "bab")]
    [InlineData("racecar", "racecar")]
    public void Can_Find_Longest_Palindromic_Substring(string input, string expected)
    {
        foreach (var strategy in strategies)
        {
            strategy.Run(input).Should().Be(expected);
        }
    }
}

public class LongestPalindromicSubstringLibTests
{
    private readonly LongestPalindromicSubstringLib lib = new(
        new FakeStrategy());

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Run_Throws_Exception_When_Input_Is_Null_Empty_Or_Whitespace(string badInput)
    {
        var badAct = () => lib.Run(badInput);

        badAct.Should()
            .Throw<ArgumentException>()
            .WithMessage("Input cannot be null, empty, or only whitespace. (Parameter 'input')");
    }

    [Fact]
    public void Run_Throws_Exception_When_Input_Too_Long()
    {
        var badInput = new string('a', 1001);

        var badAct = () => lib.Run(badInput);

        badAct.Should()
            .Throw<ArgumentException>()
            .WithMessage("Input cannot be longer than 1000 characters. (Parameter 'input')");
    }
}

internal class FakeStrategy : ILongestPalindromicSubstringStrategy
{
    public string Run(string input)
    {
        return "foo";
    }
}
