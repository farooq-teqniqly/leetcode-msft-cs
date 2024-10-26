namespace LeetcodeMsft.Lib;

public class ArrayProblems
{
    /// <summary>
    /// Calculates the running sum of an array.
    /// </summary>
    /// <param name="input">The input array.</param>
    /// <returns>The running sum array.</returns>
    public static int[] RunningSum(int[] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        for (var i = 1; i < input.Length; i++)
        {
            input[i] += input[i - 1];
        }

        return input;
    }

    /// <summary>
    /// Checks if the input array contains any duplicates.
    /// </summary>
    /// <param name="input">The input array.</param>
    /// <returns>True if the array contains duplicates, false otherwise.</returns>
    public static bool ContainsDuplicates(int[] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var set = new HashSet<int>();

        foreach (var number in input)
        {
            if (!set.Add(number))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Calculates the absolute difference between the left and right sum of each element in the input array.
    /// </summary>
    /// <param name="input">The input array.</param>
    /// <returns>An array containing the absolute difference between the left and right sum of each element.</returns>
    public static int[] LeftRightSum(int[] input)
    {
        var total = input.Sum();
        var output = new int[input.Length];
        var leftSum = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var currentNum = input[i];
            var rightSum = total - leftSum - currentNum;
            output[i] = Math.Abs(leftSum - rightSum);
            leftSum += currentNum;
        }

        return output;
    }

    /// <summary>
    /// Calculates the maximum altitude reached during a journey.
    /// </summary>
    /// <param name="input">The array of altitude changes during the journey.</param>
    /// <returns>The maximum altitude reached.</returns>
    public static int MaxAltitude(int[] input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var maxAltitude = 0;
        var currentAltitude = 0;

        foreach (var number in input)
        {
            currentAltitude += number;

            if (currentAltitude > maxAltitude)
            {
                maxAltitude = currentAltitude;
            }
        }

        return maxAltitude;
    }
}
