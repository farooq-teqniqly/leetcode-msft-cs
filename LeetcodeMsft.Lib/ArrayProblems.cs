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

        /// <summary>
        /// Checks if the input array contains any duplicates.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <returns>True if the array contains duplicates, false otherwise.</returns>
        public static bool ContainsDuplicates(int[] input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var set = new HashSet<int>();

            foreach (var number in input)
            {
                if (!set.Add(number))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
