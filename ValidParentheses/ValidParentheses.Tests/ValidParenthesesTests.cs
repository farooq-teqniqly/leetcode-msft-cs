using FluentAssertions;
using ValidParentheses.Lib;

namespace ValidParentheses.Tests;

public class ValidParenthesesTests
{
    [Theory]
    [InlineData("(")]
    [InlineData(")")]
    [InlineData("[")]
    [InlineData("]")]
    [InlineData("{")]
    [InlineData("}")]
    public void ValidParentheses_When_Input_Is_Length_One_Returns_False(string input)
    {
        ValidParenthesesLib.Run(input).Should().BeFalse();
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("){", false)]
    [InlineData("(()", false)]
    public void ValidParentheses_Returns_Correct_Result(string input, bool expectedResult)
    {
        ValidParenthesesLib.Run(input).Should().Be(expectedResult);
    }
}