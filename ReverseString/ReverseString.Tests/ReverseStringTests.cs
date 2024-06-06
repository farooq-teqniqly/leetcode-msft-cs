using FluentAssertions;
using ReverseString.Lib;

namespace ReverseString.Tests;

public class ReverseStringTests
{
    private IReverseStringStrategy[] strategies = [
        new TwoPointerReverseStringStrategy(),
        new DotNetBuiltInReverseStringStrategy()
    ];

    [Theory]
    [InlineData("hello", "olleh")]
    [InlineData("Hannah", "hannaH")]
    [InlineData("a", "a")]
    [InlineData("   a b a b  ", "  b a b a   ")]
    public void ReverseString_Returns_Expected_Result(string input, string reversed)
    {
        foreach (var strategy in strategies)
        {
            var inputArray = input.ToCharArray();
            var reversedArray = reversed.ToCharArray();

            var lib = new ReverseStringLib(strategy);
            lib.Run(inputArray).Should().Equal(reversedArray);
        }
    }

    [Fact]
    public void ReverseString_When_Input_Is_Zero_Length_Throws_Exception()
    {
        foreach (var strategy in strategies)
        {
            var lib = new ReverseStringLib(strategy);
            var badAct = () => lib.Run(Array.Empty<char>());

            badAct.Should()
                .Throw<ArgumentException>()
                .WithMessage("Input array cannot have a zero length. (Parameter 'input')");
        }
    }

    [Fact]
    public void ReverseString_When_Input_Is_Too_Long_Throws_Exception()
    {
        foreach (var strategy in strategies)
        {
            var lib = new ReverseStringLib(strategy);

            var badInput = Enumerable.Repeat('a', (int)Math.Pow(10, 5) + 1)
                .ToArray();

            var badAct = () => lib.Run(badInput);

            badAct.Should()
                .Throw<ArgumentException>()
                .WithMessage("The maximum length of the input array is 10^5 characters. (Parameter 'input')");
        }
    }
}