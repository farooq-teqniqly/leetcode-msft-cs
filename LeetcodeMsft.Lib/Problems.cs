namespace LeetcodeMsft.Lib
{
    public class Problems
    {
        /// <summary>
        /// Finds two numbers in the input array that add up to the target value.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <param name="target">The target value.</param>
        /// <returns>An array containing the indexes of the two numbers that add up to the target value.</returns>
        public static int[] TwoSum(int[] input, int target)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var map = new Dictionary<int, int>();

            for (var i = 0; i < input.Length; i++)
            {
                var complement = target - input[i];

                if (!map.ContainsKey(complement))
                {
                    map.Add(input[i], i);
                }
                else
                {
                    return [map[complement], i];
                }
            }

            return Array.Empty<int>();
        }

        /// <summary>
        /// Finds two numbers in the input array that add up to the target value.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <param name="target">The target value.</param>
        /// <returns>An array containing the indexes of the two numbers that add up to the target value.</returns>
        public static List<int[]> TwoSumMultipleAnswersPossible(int[] input, int target)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var map = new Dictionary<int, List<int>>();
            var results = new List<int[]>();

            for (var i = 0; i < input.Length; i++)
            {
                var complement = target - input[i];

                if (map.TryGetValue(complement, out var indexes))
                {
                    foreach (var index in indexes)
                    {
                        results.Add([index, i]);
                    }
                }

                if (map.ContainsKey(input[i]))
                {
                    map[input[i]].Add(i);
                }
                else
                {
                    map.Add(input[i], [i]);
                }
            }

            return results;
        }
    }
}
