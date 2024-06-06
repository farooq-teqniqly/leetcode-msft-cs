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