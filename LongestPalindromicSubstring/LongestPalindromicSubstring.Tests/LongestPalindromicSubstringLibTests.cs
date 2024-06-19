using FluentAssertions;
using LongestPalindromicSubstring.Lib;

namespace LongestPalindromicSubstring.Tests;

public class LongestPalindromicSubstringLibTests
{
    private readonly LongestPalindromicSubstringLib lib = new(
        new FakeStrategy());

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Run_Throws_Exception_When_Input_Is_Null_Empty_Or_Whitespace(string badInput)
    {
        var badAct = () => lib.Run(badInput);

        badAct.Should()
            .Throw<ArgumentException>()
            .WithMessage("Input cannot be null, empty, or only whitespace. (Parameter 'input')");
    }

    [Fact]
    public void Run_Throws_Exception_When_Input_Too_Long()
    {
        var badInput = new string('a', 1001);

        var badAct = () => lib.Run(badInput);

        badAct.Should()
            .Throw<ArgumentException>()
            .WithMessage("Input cannot be longer than 1000 characters. (Parameter 'input')");
    }
}