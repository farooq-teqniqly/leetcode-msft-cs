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