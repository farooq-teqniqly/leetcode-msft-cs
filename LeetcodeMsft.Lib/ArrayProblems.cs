namespace LeetcodeMsft.Lib
{
    public class ArrayProblems
    {
        /// <summary>
        /// Calculates the running sum of an array.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <returns>The running sum array.</returns>
        public static int[] RunningSum(int[] input)
        {
            ArgumentNullException.ThrowIfNull(input);

            for (var i = 1; i < input.Length; i++)
            {
                input[i] += input[i - 1];
            }

            return input;
        }
    }
}
