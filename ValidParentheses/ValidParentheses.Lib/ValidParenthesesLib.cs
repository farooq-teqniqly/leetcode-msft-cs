namespace ValidParentheses.Lib;

public class ValidParenthesesLib
{
    public static bool Run(string input)
    {
        if (input.Length == 1)
        {
            return false;
        }

        var stack = new Stack<char>();

        foreach (var ch in input)
        {
            if (IsOpenParenthesisCharacter(ch))
            {
                stack.Push(ch);
            }
            else if (IsClosedParenthesisCharacter(ch))
            {
                var poppedCh = stack.Pop();

                if (!IsMatchingParenthesis(ch, poppedCh))
                {
                    return false;
                }
            }
        }

        if (stack.Count == 0)
        {
            return true;
        }

        return false;
    }

    private static bool IsMatchingParenthesis(char first, char second)
    {
        return (first == '(' && second == ')') ||
               (first == '{' && second == '}') ||
               (first == '[' && second == ']');
    }

    private static bool IsClosedParenthesisCharacter(char ch)
    {
        return ch == ')' || ch == ']' || ch == '}';
    }

    private static bool IsOpenParenthesisCharacter(char ch)
    {
        return ch == '(' || ch == '[' || ch == '{';
    }
}
