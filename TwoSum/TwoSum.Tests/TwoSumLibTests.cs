using FluentAssertions;
using TwoSum.Lib;

namespace TwoSum.Tests;

public class TwoSumLibTests
{
    [Theory]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 2, 1 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 1, 0 })]
    [InlineData(new[] { 2, 7, 11, 15 }, 10, new int[0])]
    [InlineData(new[] { 1, 1, 14, 3, 1, 11, 99 }, 12, new int[] { 5, 0 })]
    public void TwoSum_Returns_Correct_Indexes(
        int[] input,
        int target,
        int[] expectedOutput)
    {
        var indices = TwoSumLib.Run(input, target);

        indices.Should().Equal(expectedOutput);
    }

    [Theory]
    [InlineData(1)]
    [InlineData((10 * 10 * 10 * 10) + 1)]
    public void Two_Sum_Throws_Exception_When_Array_Lengths_Are_Invalid(int length)
    {
        var input = Enumerable.Repeat(0, length).ToArray();
        var badAct = () => TwoSumLib.Run(input, 1);

        badAct.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Input array must contain between 2 and 10^4 elements. (Parameter 'input')");
    }

    [Fact]
    public void Two_Sum_Throws_Exception_When_Array_Value_Is_Too_Small()
    {
        var tooSmallValue = (int)Math.Pow(10, -9) - 1;
        var badAct = () => TwoSumLib.Run([tooSmallValue, 1], 1);

        badAct.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Input array values must be between 10^-9 and 10^9. (Parameter 'input')");

    }

    [Fact]
    public void Two_Sum_Throws_Exception_When_Array_Value_Is_Too_Large()
    {
        var tooLargeValue = (int)Math.Pow(10, 9) + 1;
        var badAct = () => TwoSumLib.Run([tooLargeValue, 1], 1);

        badAct.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Input array values must be between 10^-9 and 10^9. (Parameter 'input')");

    }

    [Fact]
    public void Two_Sum_Throws_Exception_When_Target_Is_Too_Small()
    {
        var tooSmallTarget = (int)Math.Pow(10, -9) - 1;
        var badAct = () => TwoSumLib.Run([1, 1], tooSmallTarget);

        badAct.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Target must be between 10^-9 and 10^9. (Parameter 'target')");

    }

    [Fact]
    public void Two_Sum_Throws_Exception_When_Target_Is_Too_Large()
    {
        var tooLargeTarget = (int)Math.Pow(10, 9) + 1;
        var badAct = () => TwoSumLib.Run([1, 1], tooLargeTarget);

        badAct.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Target must be between 10^-9 and 10^9. (Parameter 'target')");

    }
}