namespace LeetcodeMsft.Lib
{
    public class Problems
    {
        public static int[] TwoSum(int[] input, int target)
        {
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
                    return new[] { map[complement], i };
                }
            }

            return Array.Empty<int>();
        }
    }
}
