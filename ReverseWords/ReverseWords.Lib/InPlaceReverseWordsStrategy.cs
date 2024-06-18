namespace ReverseWords.Lib;

public class InPlaceReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string input)
    {
        var s = input.ToCharArray();

        ReverseString(s, 0, s.Length - 1);
        ReverseWords(s);

        return new string(s);
    }

    private void ReverseWords(char[] inputArray)
    {
        var startWordIndex = 0;
        var endWordIndex = 0;
        var length = inputArray.Length;

        while (startWordIndex < length)
        {
            while (endWordIndex < length && inputArray[endWordIndex] != ' ')
            {
                endWordIndex++;
            }

            ReverseString(inputArray, startWordIndex, endWordIndex - 1);
            startWordIndex = endWordIndex + 1;
            endWordIndex++;
        }
    }

    private void ReverseString(
        char[] inputArray,
        int startIndex,
        int endIndex)
    {
        while (startIndex < endIndex)
        {
            (inputArray[endIndex], inputArray[startIndex]) = (inputArray[startIndex], inputArray[endIndex]);

            startIndex++;
            endIndex--;
        }
    }

}