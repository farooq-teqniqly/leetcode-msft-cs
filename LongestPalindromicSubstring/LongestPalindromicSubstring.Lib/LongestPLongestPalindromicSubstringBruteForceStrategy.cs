namespace LongestPalindromicSubstring.Lib;

public class LongestPLongestPalindromicSubstringBruteForceStrategy : ILongestPalindromicSubstringStrategy
{
    public string Run(string input)
    {
        var longestPalindromicSubstring = string.Empty;

        for (var trailingIndex = 0; trailingIndex < input.Length - 1; trailingIndex++)
        {
            for (var leadingIndex = trailingIndex + 1; leadingIndex < input.Length; leadingIndex++)
            {
                if (input[leadingIndex] != input[trailingIndex])
                {
                    continue;
                }

                var length = leadingIndex - trailingIndex + 1;

                if (length > longestPalindromicSubstring.Length)
                {
                    longestPalindromicSubstring = input.Substring(trailingIndex, length);
                }
            }
        }

        return longestPalindromicSubstring;
    }
}