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

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, false)]
        [InlineData(new[] { 1, 2, 3, 1 }, true)]
        [InlineData(new int[] { }, false)]
        public void ContainsDuplicate_Returns_Expected_Result(int[] input, bool expectedResult)
        {
            ArrayProblems.ContainsDuplicates(input).Should().Be(expectedResult);
        }

        [Fact]
        public void ContainsDuplicates_When_Input_Null_Throws()
        {
            var badAct = () => ArrayProblems.ContainsDuplicates(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new[] { 2, 5, 1, 6, 1 }, new[] { 13, 6, 0, 7, 14 })]
        [InlineData(new[] { 3, 3, 3 }, new[] { 6, 0, 6 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 14, 11, 6, 1, 10 })]
        [InlineData(new int[] { }, new int[] { })]
        public void LeftRightSum_Returns_Expected_Result(int[] input, int[] expectedResult)
        {
            ArrayProblems.LeftRightSum(input).Should().Equal(expectedResult);
        }

        [Fact]
        public void LeftRightSum_When_Input_Null_Throws()
        {
            var badAct = () => ArrayProblems.LeftRightSum(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new[] { 2, 2, -3, -1, 2, 1, -5 }, 4)]
        [InlineData(new[] { 4, -3, 2, -1, -2 }, 4)]
        [InlineData(new[] { -5, 1, 5, 0, -7 }, 1)]
        [InlineData(new[] { -1 }, 0)]
        [InlineData(new int[] { }, 0)]
        public void MaxAltitude_Returns_Expected_Result(int[] input, int expectedResult)
        {
            ArrayProblems.MaxAltitude(input).Should().Be(expectedResult);
        }

        [Fact]
        public void MaxAltitude_When_Input_Null_Throws()
        {
            var badAct = () => ArrayProblems.MaxAltitude(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}
