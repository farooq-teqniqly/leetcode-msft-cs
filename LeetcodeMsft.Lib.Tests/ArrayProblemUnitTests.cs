using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests
{
    public class ArrayProblemUnitTests
    {
        [Theory]
        [InlineData(new[] { 2, 3, 5, 1, 6 }, new[] { 2, 5, 10, 11, 17 })]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { -1, 2, -3, 4, -5 }, new[] { -1, 1, -2, 2, -3 })]
        [InlineData(new[] { 4 }, new[] { 4 })]
        [InlineData(new[] { 4, -3 }, new[] { 4, 1 })]
        [InlineData(new int[] { }, new int[] { })]
        public void RunningSum_Returns_Expected_Result(int[] input, int[] expectedResult)
        {
            ArrayProblems.RunningSum(input).Should().Equal(expectedResult);
        }

        [Fact]
        public void RunningSum_When_Input_Null_Throws()
        {
            var badAct = () => ArrayProblems.RunningSum(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}
