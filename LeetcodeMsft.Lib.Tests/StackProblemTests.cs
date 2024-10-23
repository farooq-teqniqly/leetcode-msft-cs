using FluentAssertions;

namespace LeetcodeMsft.Lib.Tests
{
    public class StackProblemTests
    {
        [Theory]
        [InlineData("Hello, World!", "!dlroW ,olleH")]
        [InlineData("Stacks are fun!", "!nuf era skcatS")]
        [InlineData("   ", "   ")]
        [InlineData("", "")]
        public void ReverseString_Returns_Expected_Result(string input, string expectedResult)
        {
            StackProblems.ReverseString(input).Should().Be(expectedResult);
        }

        [Fact]
        public void ReverseString_When_Input_Null_Throws()
        {
            var badAct = () => StackProblems.ReverseString(null!);
            badAct.Should().Throw<ArgumentNullException>();
        }
    }
}
