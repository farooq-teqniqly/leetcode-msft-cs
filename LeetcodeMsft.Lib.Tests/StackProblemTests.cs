using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests;

public class StackProblemTests
{
    [Theory]
    [InlineData("Hello, World!", "!dlroW ,olleH")]
    [InlineData("Stacks are fun!", "!nuf era skcatS")]
    [InlineData("   ", "   ")]
    [InlineData("", "")]
    public void ReverseString_Returns_Expected_Result(string input, string expectedResult)
    {
        StackProblems.ReverseString(input).Should().Be(expectedResult);
    }

    [Fact]
    public void ReverseString_When_Input_Null_Throws()
    {
        var badAct = () => StackProblems.ReverseString(null!);
        badAct.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(0, "0")]
    [InlineData(1, "1")]
    [InlineData(2, "10")]
    [InlineData(7, "111")]
    [InlineData(18, "10010")]
    public void Can_Convert_Decimal_To_Binary(int input, string expectedResult)
    {
        StackProblems.DecimalToBinary(input).Should().Be(expectedResult);
    }

    [Fact]
    public void DecimalToBinary_When_Input_Negative_Throws()
    {
        var act = () => StackProblems.DecimalToBinary(-1);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
