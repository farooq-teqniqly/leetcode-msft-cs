using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests
{
    public class ProblemUnitTests
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

        [Fact]
        public void TwoSum_When_Input_Null_Throws()
        {
            var badAct = () => Problems.TwoSum(null!, 0);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TwoSumMultipleAnswersPossible_Returns_Expected_Result()
        {
            var input = new[] { 3, 1, 4, 0, 1 };
            var target = 4;
            var expectedResult = new List<int[]> { new[] { 0, 1 }, new[] { 2, 3 }, new[] { 0, 4 } };

            var actualResult = Problems.TwoSumMultipleAnswersPossible(input, target);

            for (var i = 0; i < expectedResult.Count; i++)
            {
                actualResult[i].SequenceEqual(expectedResult[i]).Should().BeTrue();
            }
        }

        [Fact]
        public void TwoSumMultipleAnswersPossible_When_Input_Null_Throws()
        {
            var badAct = () => Problems.TwoSumMultipleAnswersPossible(null!, 0);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new[] { 1, 6, 4, 10, 2, 5 }, new[] { -1, 1, 1, 4, 1, 2 })]
        [InlineData(new[] { 10, 10, 10 }, new[] { -1, -1, -1 })]
        public void NearestSmallerNumber_Returns_Expected_Result(int[] input, int[] expectedResult)
        {
            Problems.NearestSmallerNumber(input).SequenceEqual(expectedResult).Should().BeTrue();
        }

        [Fact]
        public void NearestSmallerNumber_When_Input_Null_Throws()
        {
            var badAct = () => Problems.NearestSmallerNumber(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new[] { 4, 1, 0, 3, 6 }, 13, new[] { 2, 3, 4 })]
        [InlineData(new[] { -1, 0, 1 }, 0, new[] { 0, 1, 2 })]
        [InlineData(new[] { 1, 1, 1 }, 5, new int[] { })]
        public void ThreeSum_Returns_Expected_Result(int[] input, int target, int[] expectedResult)
        {
            Problems.ThreeSum(input, target).SequenceEqual(expectedResult).Should().BeTrue();
        }

        [Fact]
        public void ThreeSum_When_Input_Null_Throws()
        {
            var badAct = () => Problems.ThreeSum(null!, 0);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}