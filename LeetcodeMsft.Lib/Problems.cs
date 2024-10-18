namespace LeetcodeMsft.Lib
{
    public class Problems
    {
        /// <summary>
        /// Finds the nearest smaller number for each element in the input array.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <returns>An array containing the nearest smaller number for each element in the input array.</returns>
        public static int[] NearestSmallerNumber(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var output = new int[input.Length];
            var stack = new Stack<int>();

            for (var i = 0; i < input.Length; i++)
            {
                while (stack.Count != 0 && stack.Peek() >= input[i])
                {
                    var _ = stack.Pop();
                }

                output[i] = stack.Count == 0 ? -1 : stack.Peek();

                stack.Push(input[i]);
            }

            return output;
        }

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
