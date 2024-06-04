namespace TwoSum.Lib;

public class TwoSumLib
{
    private static readonly double MinAllowedValue = Math.Pow(10, -9);
    private static readonly double MaxAllowedValue = Math.Pow(10, 9);

    public static int[] Run(int[] input, int target)
    {
        if (ArrayTooShort(input) || ArrayTooLong(input))
        {
            throw new ArgumentOutOfRangeException(
                nameof(input),
                "Input array must contain between 2 and 10^4 elements.");
        }

        if (TargetTooSmall(target) || TargetTooLarge(target))
        {
            throw new ArgumentOutOfRangeException(
                nameof(target),
                "Target must be between 10^-9 and 10^9.");
        }

        var dictionary = new Dictionary<int, int>();

        for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
        {
            if (ArrayValueTooSmall(input, currentIndex) || ArrayValueTooLarge(input, currentIndex))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(input),
                    "Input array values must be between 10^-9 and 10^9.");
            }

            var currentValue = input[currentIndex];
            var remaining = target - currentValue;

            if (dictionary.TryGetValue(remaining, out var index))
            {
                return [currentIndex, index];
            }

            dictionary.TryAdd(currentValue, currentIndex);
        }

        return [];
    }

    private static bool ArrayValueTooLarge(int[] input, int currentIndex)
    {
        return input[currentIndex] > MaxAllowedValue;
    }

    private static bool ArrayValueTooSmall(int[] input, int currentIndex)
    {
        return input[currentIndex] < MinAllowedValue;
    }

    private static bool TargetTooLarge(int target)
    {
        return target > MaxAllowedValue;
    }

    private static bool TargetTooSmall(int target)
    {
        return (double)target < MinAllowedValue;
    }

    private static bool ArrayTooLong(int[] input)
    {
        return input.Length > Math.Pow(10, 4);
    }

    private static bool ArrayTooShort(int[] input)
    {
        return input.Length < 2;
    }
}
