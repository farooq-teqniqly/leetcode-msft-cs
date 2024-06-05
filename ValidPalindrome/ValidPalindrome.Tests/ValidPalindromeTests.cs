using FluentAssertions;
using ValidPalindrome.Lib;

namespace ValidPalindrome.Tests;

public class ValidPalindromeTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("    ")]
    public void Empty_String_Is_A_Valid_Palindrome(string input)
    {
        ValidPalindromeLib.Run(input).Should().BeTrue();
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("abbba", true)]
    [InlineData("race a car", false)]
    [InlineData(".", true)]
    [InlineData(".,", true)]
    [InlineData("aa", true)]
    [InlineData("a", true)]
    public void ValidPalindrome_Returns_Correct_Result(string input, bool expectedResult)
    {
        ValidPalindromeLib.Run(input).Should().Be(expectedResult);
    }

    [Fact]
    public void ValidPalindrome_Throws_When_Input_Is_Too_Long()
    {
        var length = (int)(2 * Math.Pow(10, 5)) + 1;
        var input = new string('a', length);

        var badAct = () => ValidPalindromeLib.Run(input);

        badAct.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("Maximum length of the input is 2 * 10^5 characters. (Parameter 'input')");
    }
}