namespace LeetcodeMsft.Lib
{
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
    }
}
