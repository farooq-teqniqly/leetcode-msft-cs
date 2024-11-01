namespace LeetcodeMsft.Lib;
public class StreamingProblems
{
    /// <summary>
    /// Finds the majority element in the input array.
    /// </summary>
    /// <param name="input">The input array.</param>
    /// <returns>The majority element.</returns>
    public static int MajorityElement(int[] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.Length == 0)
        {
            throw new ArgumentException(
                "Input array must have at least one element.",
                nameof(input));
        }

        var majority = input[0];
        var votes = 0;

        foreach (var candidate in input)
        {
            if (votes == 0)
            {
                majority = candidate;
            }

            if (candidate == majority)
            {
                votes++;
            }
            else
            {
                votes--;
            }
        }

        return majority;
    }
}
