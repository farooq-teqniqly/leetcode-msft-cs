namespace ValidPalindrome.Lib;

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