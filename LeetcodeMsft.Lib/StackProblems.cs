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

    /// <summary>
    /// Finds the next greatest number for each element in the input array.
    /// </summary>
    /// <param name="input">The input array.</param>
    /// <returns>An array containing the next greatest number for each element in the input array.</returns>
    public static int[] NextGreatestNumber(int[] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var output = new int[input.Length];
        var stack = new Stack<int>();

        for (var i = input.Length - 1; i >= 0; i--)
        {
            var currentNum = input[i];

            while (stack.Count != 0 && stack.Peek() <= currentNum)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                output[i] = -1;
            }
            else
            {
                output[i] = stack.Peek();
            }

            stack.Push(currentNum);
        }

        return output;
    }
}
