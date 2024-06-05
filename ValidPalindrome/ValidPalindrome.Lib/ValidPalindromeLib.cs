namespace ValidPalindrome.Lib;

public class ValidPalindromeLib
{
    private static readonly int MaxInputLength = (int)Math.Pow(10, 5) * 2;
    public static bool Run(string input)
    {
        if (input.Length > MaxInputLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(input),
                "Maximum length of the input is 2 * 10^5 characters.");
        }

        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        if (input.Length == 1)
        {
            return true;
        }

        var frontIndex = 0;
        var backIndex = input.Length - 1;

        while (frontIndex <= backIndex)
        {
            while (!IsValidCharacter(input, frontIndex) && frontIndex < input.Length - 1)
            {
                frontIndex++;
            }

            while (!IsValidCharacter(input, backIndex) && backIndex > 0)
            {
                backIndex--;
            }

            if (frontIndex == input.Length - 1 && backIndex == 0)
            {
                return true;
            }

            if (!CharactersAreEqual(input, frontIndex, backIndex))
            {
                return false;
            }

            frontIndex++;
            backIndex--;
        }

        return true;
    }

    private static bool CharactersAreEqual(string input, int frontIndex, int backIndex)
    {
        return char.ToLowerInvariant(input[frontIndex]) == char.ToLowerInvariant(input[backIndex]);
    }

    private static bool IsValidCharacter(string input, int index)
    {
        return char.IsLetterOrDigit(input[index]);
    }
}
