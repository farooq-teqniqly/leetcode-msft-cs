using System.Text;

namespace LeetcodeMsft.Lib;

public class StackProblems
{
    /// <summary>
    /// Reverses a string.
    /// </summary>
    /// <param name="input">The input string to be reversed.</param>
    /// <returns>The reversed string.</returns>
    public static string ReverseString(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var stack = new Stack<char>();

        foreach (var ch in input)
        {
            stack.Push(ch);
        }

        var output = new char[input.Length];
        var index = 0;

        while (stack.Count != 0)
        {
            output[index] = stack.Pop();
            index++;
        }

        return new string(output);
    }
    /// <summary>
    /// Converts a decimal number to binary representation.
    /// </summary>
    /// <param name="input">The decimal number to convert.</param>
    /// <returns>The binary representation of the decimal number.</returns>
    public static string DecimalToBinary(int input)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(input, 0);

        if (input == 0)
        {
            return "0";
        }

        var stack = new Stack<int>();

        var divisor = input;

        while (divisor > 0)
        {
            stack.Push((divisor % 2));
            divisor /= 2;
        }

        var output = new StringBuilder(stack.Count);
        
        while (stack.Count != 0)
        {
            output.Append(stack.Pop());
        }
        
        return output.ToString();
    }
}
