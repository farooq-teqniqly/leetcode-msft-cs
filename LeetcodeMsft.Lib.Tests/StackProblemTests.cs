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

    [Theory]
    [InlineData(new[] { 4, 5, 2, 25 }, new[] { 5, 25, 25, -1 })]
    [InlineData(new[] { 13, 7, 6, 12 }, new[] {-1, 12, 12, -1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] {2 ,3, 4, 5, -1 })]
    [InlineData(new[] { 0 }, new[] { -1 })]
    [InlineData(new[] { 0, 0 }, new[] { -1, -1 })]
    [InlineData(new int[] {}, new int[] {})]
    public void NextGreatestNumber_Returns_Expected_Result(int[] input, int[] expectedResult)
    {
        StackProblems.NextGreatestNumber(input).Should().Equal(expectedResult);
    }

    [Fact]
    public void NextGreatestNumber_When_Input_Null_Throws()
    {
        var act = () => StackProblems.NextGreatestNumber(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(new[] { 34, 3, 31, 98, 92, 23 }, new[] { 3, 23, 31, 34, 92, 98 })]
    [InlineData(new[] { 4, 3, 2, 10, 12, 1, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6, 10, 12 })]
    [InlineData(new[] { 20, 10, -5, -1 }, new[] { -5, -1, 10, 20 })]
    [InlineData(new[] {1, 2, 3 }, new[] { 1, 2, 3 })]
    [InlineData(new[] {1 }, new[] { 1 })]
    [InlineData(new int[] {}, new int[] {})]
    public void StackSort_Returns_Expected_Result(int[] input, int[] expectedResult)

    {
        StackProblems.StackSort(input).Should().Equal(expectedResult);
    }

    [Fact]
    public void StackSort_When_Input_Null_Throws()
    {
        var act = () => StackProblems.StackSort(null!);
        act.Should().Throw<ArgumentNullException>();
    }
}
