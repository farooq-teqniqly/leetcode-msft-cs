namespace ReverseWords.Lib;

public class InPlaceReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string input)
    {
        var inputArray = input.ToCharArray();

        ReverseString(inputArray, 0, inputArray.Length - 1);
        ReverseWords(inputArray);

        return new string(inputArray);
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

    private void ReverseString(char[] inputArray, int startIndex, int endIndex)
    {
        while (startIndex < endIndex)
        {
            char tmp = inputArray[endIndex];

            inputArray[endIndex] = inputArray[startIndex];
            inputArray[startIndex] = tmp;

            startIndex++;
            endIndex--;
        }
    }

}