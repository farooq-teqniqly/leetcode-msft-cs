namespace ReverseString.Lib;

public class ReverseStringLib(IReverseStringStrategy strategy)
{
    private const int MaxInputLength = 100_000;

    public char[] Run(char[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException(
                "Input array cannot have a zero length.",
                nameof(input));
        }

        if (input.Length > MaxInputLength)
        {
            throw new ArgumentException(
                "The maximum length of the input array is 10^5 characters.",
                nameof(input));
        }

        return strategy.Run(input);
    }


}