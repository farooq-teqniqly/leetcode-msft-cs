namespace ReverseString.Lib;

public class ReverseStringLib
{
    private const int MaxInputLength = 100_000;

    public static char[] Run(char[] input)
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

        var frontIndex = 0;
        var backIndex = input.Length - 1;

        while (frontIndex < backIndex)
        {
            Swap(input, frontIndex, backIndex);
            frontIndex++;
            backIndex--;
        }

        return input;
    }

    private static void Swap(char[] input, int frontIndex, int backIndex)
    {
        (input[frontIndex], input[backIndex]) = (input[backIndex], input[frontIndex]);
    }
}
