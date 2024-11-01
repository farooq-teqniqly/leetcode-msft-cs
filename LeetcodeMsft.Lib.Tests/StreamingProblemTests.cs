using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests;
public class StreamingProblemTests
{
    [Theory]
    [InlineData(new int[] { 3, 2, 3 }, 3)]
    [InlineData(new int[] { 2, 2, 1, 1, 1, 2, 2, 2, 2, 1 }, 2)]
    public void MajorityElement_Returns_Expected_Result(int[] input, int expectedResult)
    {
        StreamingProblems.MajorityElement(input).Should().Be(expectedResult);
    }

    [Fact]
    public void MajorityElement_When_Input_Null_Throws()
    {
        var act = () => StreamingProblems.MajorityElement(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void MajorityElement_When_Input_Array_Is_Empty_Throws()
    {
        var act = () => StreamingProblems.MajorityElement([]);
        act.Should().Throw<ArgumentException>();
    }
}
