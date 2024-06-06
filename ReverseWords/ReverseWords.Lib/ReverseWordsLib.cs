namespace ReverseWords.Lib;

public class ReverseWordsLib(IReverseWordsStrategy strategy)
{
    private const int MaxInputLength = 10000;

    public string Run(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(
                "Input string cannot be null or whitespace only.",
                nameof(input));
        }

        if (input.Length > MaxInputLength)
        {
            throw new ArgumentException(
                "Maximum length of input string is 10^4 characters.",
                nameof(input));
        }
        return strategy.Run(input);
    }
}