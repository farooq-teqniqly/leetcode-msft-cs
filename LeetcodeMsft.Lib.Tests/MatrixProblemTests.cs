using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests
{
    public class MatrixProblemTests
    {
        [Fact]
        public void RichestCustomer_Returns_Expected_Result()
        {
            var testData = new List<Tuple<int[][], int>>
            {
                new(
                [
                    [5, 2, 3],
                    [0, 6, 7]
                ], 13),
                new(
                [
                    [1, 2],
                    [3, 4],
                    [5, 6]
                ], 11),
                new(
                [
                    [10, 100],
                    [200, 20],
                    [30, 300]
                ], 330),
                new(
                [
                    [10, 100],
                    [200, 20],
                    [30]
                ], 220),
                new(
                [
                    [10, 100, 50, 100],
                    [200, 20],
                    [30]
                ], 260)
            };

            foreach (var item in testData)
            {
                MatrixProblems.RichestCustomer(item.Item1).Should().Be(item.Item2);
            }
        }

        [Fact]
        public void RichestCustomer_When_Input_Null_Throws()
        {
            var badAct = () => MatrixProblems.RichestCustomer(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}
