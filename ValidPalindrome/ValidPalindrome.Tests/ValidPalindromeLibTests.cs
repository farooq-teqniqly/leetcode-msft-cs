using FluentAssertions;
using ValidPalindrome.Lib;

namespace ValidPalindrome.Tests;

public class ValidPalindromeLibTests
{
    internal class FakeValidPalindromeStrategy : IValidPalindromeStrategy
    {
        public bool Run(string input)
        {
            return true;
        }
    }

    private readonly ValidPalindromeLib lib = new(new FakeValidPalindromeStrategy());

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("    ")]
    public void Empty_String_Is_A_Valid_Palindrome(string input)
    {
        lib.Run(input).Should().BeTrue();
    }

    [Fact]
    public void ValidPalindrome_Throws_When_Input_Is_Too_Long()
    {
        var length = (int)(2 * Math.Pow(10, 5)) + 1;
        var input = new string('a', length);

        var badAct = () => lib.Run(input);

        badAct.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("Maximum length of the input is 2 * 10^5 characters. (Parameter 'input')");
    }


    [Theory]
    [InlineData(".")]
    [InlineData("a")]
    public void Input_Of_Length_1_Is_Valid_Palindrome(string input)
    {
        lib.Run(input).Should().BeTrue();
    }

    [Fact]
    public void Run_Method_Of_Strategy_Is_Called()
    {
        lib.Run("abba").Should().BeTrue();
    }
}