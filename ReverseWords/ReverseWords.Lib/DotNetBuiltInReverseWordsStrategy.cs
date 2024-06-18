using System.Text;

namespace ReverseWords.Lib;

public class DotNetBuiltInReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string s)
    {
        var reversedArray = s.Split(
                " ",
                StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .ToArray();

        return string.Join(" ", reversedArray);
    }
}

public class ManualReverseWordsStrategy : IReverseWordsStrategy
{
    public string Run(string s)
    {
        var wordStack = new Stack<string>();

        for (var currentIndex = 0; currentIndex < s.Length; currentIndex++)
        {
            // Ignore leading and trailing whitespace
            if (s[currentIndex] == ' ')
            {
                continue;
            }

            var wordBuilder = new StringBuilder();

            while (currentIndex < s.Length && s[currentIndex] != ' ')
            {
                wordBuilder.Append(s[currentIndex]);
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