namespace LeetcodeMsft.Lib;

public class MatrixProblems
{
    /// <summary>
    /// Calculates the wealth of the richest customer based on their accounts.
    /// </summary>
    /// <param name="accounts">The array of customer accounts.</param>
    /// <returns>The wealth of the richest customer.</returns>
    public static int RichestCustomer(int[][] accounts)
    {
        ArgumentNullException.ThrowIfNull(accounts);

        var customerCount = accounts.Length;
        var maxWealth = int.MinValue;

        for (var i = 0; i < customerCount; i++)
        {
            var wealth = 0;

            for (var j = 0; j < accounts[i].Length; j++)
            {
                wealth += accounts[i][j];
            }

            if (wealth > maxWealth)
            {
                maxWealth = wealth;
            }
        }

        return maxWealth;
    }

    /// <summary>
    /// Calculates the sum of the diagonal elements in a square matrix.
    /// </summary>
    /// <param name="input">The input matrix.</param>
    /// <returns>The sum of the diagonal elements.</returns>
    public static int DiagonalSum(int[][] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var sum = 0;
        var rowCount = input.Length;

        foreach (var row in input)
        {
            if (row.Length != rowCount)
            {
                throw new ArgumentException("The input matrix must be square.", nameof(input));
            }
        }

        for (var i = 0; i < rowCount; i++)
        {
            sum += input[i][i];
            sum += input[i][rowCount - i - 1];
        }

        if (rowCount % 2 != 0)
        {
            sum -= input[rowCount / 2][rowCount / 2];
        }

        return sum;
    }

    /// <summary>
    /// Finds the row index and count of the row with the maximum number of ones in a matrix.
    /// </summary>
    /// <param name="input">The input matrix.</param>
    /// <returns>An array containing the row index and count of the row with the maximum number of ones.</returns>
    public static int[] MaxOnes(int[][] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var rowCount = input.Length;
        var maxOnesCount = 0;
        var maxOnesIndex = 0;

        for (var i = 0; i < rowCount; i++)
        {
            var currentOnesCount = 0;

            for (var j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 1)
                {
                    currentOnesCount++;
                }
            }

            if (currentOnesCount > maxOnesCount)
            {
                maxOnesCount = currentOnesCount;
                maxOnesIndex = i;
            }
        }

        return [maxOnesIndex, maxOnesCount];
    }
}
