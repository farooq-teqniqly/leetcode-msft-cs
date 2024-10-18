namespace LeetcodeMsft.Lib
{
    using System.Diagnostics.CodeAnalysis;

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
        /// Finds all triplets in the input array that sum up to the target value.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <param name="target">The target value.</param>
        /// <returns>A list of arrays, each containing three numbers that sum up to the target value.</returns>
        public static HashSet<int[]> ThreeSum(int[] input, int target)
        {
            Array.Sort(input);
            var output = new HashSet<int[]>(new IntArrayComparer());

            for (var i = 0; i < input.Length; i++)
            {
                var left = i + 1;
                var right = input.Length - 1;

                while (left < right)
                {
                    var currentNumber = input[i];
                    var leftNumber = input[left];
                    var rightNumber = input[right];

                    var sum = currentNumber + leftNumber + rightNumber;

                    if (sum == target)
                    {
                        output.Add(new[] { currentNumber, leftNumber, rightNumber });
                        break;

                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
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

    internal class IntArrayComparer : IEqualityComparer<int[]>
    {
        /// <summary>
        /// Determines whether two int arrays are equal.
        /// </summary>
        /// <param name="x">The first int array.</param>
        /// <param name="y">The second int array.</param>
        /// <returns>True if the int arrays are equal; otherwise, false.</returns>
        public bool Equals(int[]? x, int[]? y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (x.Length != y.Length)
            {
                return false;
            }

            Array.Sort(x);
            Array.Sort(y);

            for (var i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates the hash code for the specified int array.
        /// </summary>
        /// <param name="obj">The int array.</param>
        /// <returns>The calculated hash code.</returns>
        public int GetHashCode([DisallowNull] int[] obj)
        {
            Array.Sort(obj);

            var hash = 39;

            foreach (var n in obj)
            {
                hash = (hash * 31) + n;
            }

            return hash;
        }
    }
}
