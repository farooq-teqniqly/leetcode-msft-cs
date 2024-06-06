namespace ReverseString.Lib;

public class DotNetBuiltInReverseStringStrategy : IReverseStringStrategy
{
    public char[] Run(char[] input)
    {
        Array.Reverse(input);
        return input;
    }
}