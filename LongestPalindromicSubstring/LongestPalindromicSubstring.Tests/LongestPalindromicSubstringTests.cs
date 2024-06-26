using FluentAssertions;
using LongestPalindromicSubstring.Lib;

namespace LongestPalindromicSubstring.Tests;

public class LongestPalindromicSubstringTests
{
    private ILongestPalindromicSubstringStrategy[] strategies =
    [
        new LongestPalindromicSubstringNSquaredStrategy(),
        new LongestPLongestPalindromicSubstringBruteForceStrategy()
    ];

    [Theory]
    [InlineData("a", "a")]
    [InlineData("abbc", "bb")]
    [InlineData("babad", "bab")]
    [InlineData("racecar", "racecar")]
    [InlineData("aacabdkacaa", "aca")]
    public void Can_Find_Longest_Palindromic_Substring(string input, string expected)
    {
        foreach (var strategy in strategies)
        {
            strategy.Run(input).Should().Be(expected);
        }
    }
}