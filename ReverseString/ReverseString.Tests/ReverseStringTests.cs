using FluentAssertions;
using ReverseString.Lib;

namespace ReverseString.Tests;

public class ReverseStringTests
{
    [Theory]
    [InlineData("hello", "olleh")]
    [InlineData("Hannah", "hannaH")]
    public void Reverse_String_Returns_Expected_Result(string input, string reversed)
    {
        var inputArray = input.ToCharArray();
        var reversedArray = reversed.ToCharArray();

        ReverseStringLib.Run(inputArray).Should().Equal(reversedArray);
    }
}