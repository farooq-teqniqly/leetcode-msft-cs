namespace ReverseWords.Lib;

public class ReverseWordsLib(IReverseWordsStrategy strategy)
{
    public string Run(string input)
    {
        return strategy.Run(input);
    }
}