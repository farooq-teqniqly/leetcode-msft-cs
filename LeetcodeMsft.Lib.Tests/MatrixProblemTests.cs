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

        [Fact]
        public void DiagonalSum_Returns_Expected_Result()
        {
            var testData = new List<Tuple<int[][], int>>();

            testData.Add(new(
                [
                    [1, 2, 3],
                    [4, 5, 6],
                    [7, 8, 9]
                ], 25));

            testData.Add(new(
            [
                [1, 0],
                [0, 1]
            ], 2));

            testData.Add(new(
            [
                [5]
            ], 5));

            foreach (var item in testData)
            {
                MatrixProblems.DiagonalSum(item.Item1).Should().Be(item.Item2);
            }
        }

        [Fact]
        public void DiagonalSum_When_Input_Null_Throws()
        {
            var badAct = () => MatrixProblems.DiagonalSum(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DiagonalSum_When_Matrix_Not_Square_Throws()
        {
            int[][] input = [
                [1, 2, 3],
                [4, 5],
                [7, 8, 9]
            ];

            var badAct = () => MatrixProblems.DiagonalSum(input);
            badAct.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void MaxOnes_Returns_Expected_Results()
        {
            var testData = new List<Tuple<int[][], int[]>>
            {
                new(
                [
                    [1, 0],
                    [1, 1],
                    [0, 1]
                ], [1, 2]),

                new(
                [
                    [0, 1, 1],
                    [0, 1, 1],
                    [1, 1, 1]
                ], [2, 3]),

                new(
                [
                    [1, 0, 1],
                    [0, 0, 1],
                    [1, 1, 0]
                ], [0, 2]),

                new(
                [
                    []
                ], [0, 0])
            };

            foreach (var item in testData)
            {
                MatrixProblems.MaxOnes(item.Item1).Should().Equal(item.Item2);
            }
        }

        [Fact]
        public void MaxOnes_When_Input_Null_Throws()
        {
            var badAct = () => MatrixProblems.MaxOnes(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}
