namespace ValidParentheses.Lib;

public class ValidParenthesesLib
{
    public static bool Run(string s)
    {
        if (s.Length == 1)
        {
            return false;
        }

        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (IsOpenParenthesisCharacter(ch))
            {
                stack.Push(ch);
            }
            else if (IsClosedParenthesisCharacter(ch))
            {
                var popped = stack.TryPop(out var poppedCh);

                if (!popped)
                {
                    return false;
                }

                if (!IsMatchingParenthesis(poppedCh, ch))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    private static bool IsMatchingParenthesis(char first, char second)
    {
        return (first == '(' && second == ')') ||
               (first == '{' && second == '}') ||
               (first == '[' && second == ']');
    }

    private static bool IsClosedParenthesisCharacter(char ch)
    {
        return ch is ')' or ']' or '}';
    }

    private static bool IsOpenParenthesisCharacter(char ch)
    {
        return ch is '(' or '[' or '{';
    }
}
