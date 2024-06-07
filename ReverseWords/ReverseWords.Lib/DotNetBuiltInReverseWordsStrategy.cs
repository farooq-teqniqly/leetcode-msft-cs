using System.Text;

namespace ReverseWords.Lib;

public class DotNetBuiltInReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string input)
    {
        var reversedArray = input.Split(
                " ",
                StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .ToArray();

        return string.Join(" ", reversedArray);
    }
}

public class ManualReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string input)
    {
        var wordStack = new Stack<string>();

        for (var currentIndex = 0; currentIndex < input.Length; currentIndex++)
        {
            // Ignore leading and trailing whitespace
            if (input[currentIndex] == ' ')
            {
                currentIndex++;
                continue;
            }

            var wordBuilder = new StringBuilder();

            while (currentIndex < input.Length && input[currentIndex] != ' ')
            {
                wordBuilder.Append(input[currentIndex]);
                currentIndex++;
            }

            wordStack.Push(wordBuilder.ToString());
        }

        var sentenceBuilder = new StringBuilder();

        while (wordStack.Count != 0)
        {
            sentenceBuilder.Append(wordStack.Pop());

            if (wordStack.Count != 0)
            {
                sentenceBuilder.Append(' ');
            }
        }

        return sentenceBuilder.ToString();
    }
}
