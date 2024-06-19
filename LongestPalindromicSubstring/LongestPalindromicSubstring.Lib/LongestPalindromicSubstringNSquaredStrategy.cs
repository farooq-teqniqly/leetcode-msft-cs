namespace LongestPalindromicSubstring.Lib;

public class LongestPalindromicSubstringNSquaredStrategy : ILongestPalindromicSubstringStrategy
{
    public string Run(string input)
    {
        var start = 0;
        var end = 0;

        for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
        {
            var oddLength = Expand(input, currentIndex, currentIndex);

            if (oddLength > end - start + 1)
            {
                var distance = oddLength / 2;
                start = currentIndex - distance;
                end = currentIndex + distance;
            }


            var evenLength = Expand(input, currentIndex, currentIndex + 1);

            if (evenLength > end - start + 1)
            {
                var distance = (evenLength / 2) - 1;
                start = currentIndex - distance;
                end = currentIndex + distance + 1;
            }
        }

        return input.Substring(start, end - start + 1);
    }

    private int Expand(string input, int leftIndex, int rightIndex)
    {
        while (leftIndex >= 0 && rightIndex < input.Length)
        {
            if (input[leftIndex] != input[rightIndex])
            {
                break;
            }

            leftIndex--;
            rightIndex++;
        }

        return rightIndex - leftIndex - 1;
    }
}