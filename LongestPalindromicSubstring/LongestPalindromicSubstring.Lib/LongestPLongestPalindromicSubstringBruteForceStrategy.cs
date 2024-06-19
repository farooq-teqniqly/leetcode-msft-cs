namespace LongestPalindromicSubstring.Lib;

public class LongestPLongestPalindromicSubstringBruteForceStrategy : ILongestPalindromicSubstringStrategy
{
    public string Run(string s)
    {
        var longestPalindromicSubstring = string.Empty;

        for (var trailingIndex = 0; trailingIndex < s.Length; trailingIndex++)
        {
            for (var leadingIndex = trailingIndex; leadingIndex < s.Length; leadingIndex++)
            {
                if (!SubstringIsPalindrome(s, trailingIndex, leadingIndex))
                {
                    continue;
                }

                var length = GetSubstringLength(leadingIndex, trailingIndex);

                if (length > longestPalindromicSubstring.Length)
                {
                    longestPalindromicSubstring = GetSubstring(s, trailingIndex, length);
                }
            }
        }

        return longestPalindromicSubstring;
    }

    private static string GetSubstring(string input, int startIndex, int length) => input.Substring(startIndex, length);

    private static int GetSubstringLength(int startIndex, int endIndex) => startIndex - endIndex + 1;

    private bool SubstringIsPalindrome(string input, int startIndex, int endIndex)
    {
        var leftIndex = startIndex;
        var rightIndex = endIndex;

        while (leftIndex < rightIndex)
        {
            if (input[leftIndex] != input[rightIndex])
            {
                return false;
            }

            leftIndex++;
            rightIndex--;
        }

        return true;
    }
}