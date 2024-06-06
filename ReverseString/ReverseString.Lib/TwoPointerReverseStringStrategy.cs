namespace ReverseString.Lib;

public class TwoPointerReverseStringStrategy : IReverseStringStrategy
{
    public char[] Run(char[] input)
    {
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