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
}
