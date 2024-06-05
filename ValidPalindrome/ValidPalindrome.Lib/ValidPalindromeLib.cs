namespace ValidPalindrome.Lib;

public class ValidPalindromeLib(IValidPalindromeStrategy strategy)
{
    private static readonly int MaxInputLength = (int)Math.Pow(10, 5) * 2;
    public bool Run(string input)
    {
        if (input.Length > MaxInputLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(input),
                "Maximum length of the input is 2 * 10^5 characters.");
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        if (input.Length == 1)
        {
            return true;
        }

        return strategy.Run(input);
    }
}

public interface IValidPalindromeStrategy
{
    public bool Run(string input);
}