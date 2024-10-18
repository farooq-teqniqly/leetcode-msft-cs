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

        [Fact]
        public void ThreeSum_Returns_Expected_Result_1()
        {
            var input = new[] { -1, 0, 1, 2, -1, -4 };
            var target = 0;

            var expectedResult = new List<int[]>()
            {
                new int[] {0, 1, 2 }, new int[] {0, 3, 4 }
            };

            var actualResult = Problems.ThreeSum(input, target);

            actualResult.Select(r => r.Sum().Should().Be(target));
        }

        [Fact]
        public void ThreeSum_Returns_Expected_Result_2()
        {
            var input = new[] { 1, 0, 0 };
            var target = 0;

            var actualResult = Problems.ThreeSum(input, target);

            actualResult.Count.Should().Be(0);
        }

        [Fact]
        public void ThreeSum_Returns_Expected_Result_3()
        {
            var input = new[] { 0, 0, 0 };
            var target = 0;

            var actualResult = Problems.ThreeSum(input, target);

            actualResult.Count.Should().Be(1);
            actualResult.Select(r => r.Sum().Should().Be(target));
        }

        [Fact]
        public void ThreeSum_Does_Not_Return_Duplicate_Triplets()
        {
            var input = new[] { 1, 2, 3, 3, 2, 1 };
            var target = 6;

            var actualResult = Problems.ThreeSum(input, target);

            actualResult.Count.Should().Be(1);
            actualResult.Select(r => r.Sum().Should().Be(target));
        }

        [Fact]
        public void ThreeSum_When_Input_Null_Throws()
        {
            var badAct = () => Problems.ThreeSum(null!, 0);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("[]", true)]
        [InlineData("()", true)]
        [InlineData("{}", true)]
        [InlineData("[[[{{{()}}}]]]", true)]
        [InlineData("[[[{{{()}}]]]", false)]
        [InlineData("[", false)]
        [InlineData("]", false)]
        [InlineData("", false)]
        [InlineData("{a} + b(c + [a/b])", true)]
        public void ValidParentheses_Returns_Expected_Result(string input, bool expectedResult)
        {
            Problems.ValidParentheses(input).Should().Be(expectedResult);
        }
    }
}