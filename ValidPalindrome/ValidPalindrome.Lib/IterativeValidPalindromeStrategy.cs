namespace ValidPalindrome.Lib;

public class IterativeValidPalindromeStrategy : IValidPalindromeStrategy
{
    public bool Run(string input)
    {
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

    private static bool CharactersAreEqual(string input, int indexOfFirstChar, int indexOfSecondChar)
    {
        return char.ToLowerInvariant(input[indexOfFirstChar]) == char.ToLowerInvariant(input[indexOfSecondChar]);
    }

    private static bool IsValidCharacter(string input, int index)
    {
        return char.IsLetterOrDigit(input[index]);
    }
}

public class LinqBasedValidPalindromeStrategy : IValidPalindromeStrategy
{
    public bool Run(string input)
    {
        var validIndexes = input.Select((ch, index) =>
            {
                if (char.IsLetterOrDigit(ch))
                {
                    return index;
                }

                return -1;
            }).Where(n => n != -1)
            .ToArray();

        if (validIndexes.Length == 0)
        {
            return true;
        }

        var frontIndex = 0;
        var backIndex = validIndexes.Length - 1;

        while (frontIndex < backIndex)
        {
            if (!CharactersAreEqual(input, validIndexes[frontIndex], validIndexes[backIndex]))
            {
                return false;
            }

            frontIndex++;
            backIndex--;
        }

        return true;
    }

    private static bool CharactersAreEqual(string input, int indexOfFirstChar, int indexOfSecondChar)
    {
        return char.ToLowerInvariant(input[indexOfFirstChar]) == char.ToLowerInvariant(input[indexOfSecondChar]);
    }
}
