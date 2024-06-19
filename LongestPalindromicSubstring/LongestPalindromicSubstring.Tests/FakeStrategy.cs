using LongestPalindromicSubstring.Lib;

namespace LongestPalindromicSubstring.Tests;

internal class FakeStrategy : ILongestPalindromicSubstringStrategy
{
    public string Run(string input)
    {
        return "foo";
    }
}