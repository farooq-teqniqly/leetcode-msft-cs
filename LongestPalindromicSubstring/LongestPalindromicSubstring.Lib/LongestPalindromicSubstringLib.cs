namespace LongestPalindromicSubstring.Lib;

public class LongestPalindromicSubstringLib(ILongestPalindromicSubstringStrategy strategy)
{
    private const int MaxInputLength = 1000;

    public string Run(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be null, empty, or only whitespace.", nameof(input));
        }

        if (input.Length > MaxInputLength)
        {
            throw new ArgumentException($"Input cannot be longer than {MaxInputLength} characters.", nameof(input));
        }

        return strategy.Run(input);
    }
}