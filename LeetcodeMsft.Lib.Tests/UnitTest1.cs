using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [InlineData(new[] { 3, 4 }, 10, new int[] { })]
        public void TwoSum_Returns_Expected_Result(int[] input, int target, int[] expectedResult)
        {
            Problems.TwoSum(input, target).Should().Equal(expectedResult);
        }
    }
}