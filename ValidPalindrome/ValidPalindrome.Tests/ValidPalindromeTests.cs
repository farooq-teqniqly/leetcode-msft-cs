using FluentAssertions;
using ValidPalindrome.Lib;

namespace ValidPalindrome.Tests;

public class IterativeValidPalindromeStrategyTests
{
    private readonly IValidPalindromeStrategy strategy = new IterativeValidPalindromeStrategy();

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("abbba", true)]
    [InlineData("race a car", false)]
    [InlineData("aa", true)]
    public void ValidPalindromeStrategy_Returns_Correct_Result(string input, bool expectedResult)
    {
        strategy.Run(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(".,")]
    [InlineData("!!!")]
    public void String_Of_Only_Non_AlphaNumeric_Characters_Is_Valid_Palindrome(string input)
    {
        strategy.Run(input).Should().BeTrue();
    }
}