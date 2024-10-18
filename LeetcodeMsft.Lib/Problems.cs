namespace LeetcodeMsft.Lib
{
    public class Problems
    {
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
