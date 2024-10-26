using FluentAssertions;
using LeetcodeMsft.Lib.DataStructures;

namespace LeetcodeMsft.Lib.Tests.DataStructures;
public class MultiValueDictionaryTests
{
    private readonly MultiValueDictionary<string, string> _mvd = new();

    [Fact]
    public void Can_Add_Key_With_Single_Value()
    {
        _mvd.Add("bird", "eagle").Should().BeTrue();
        _mvd.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
    }

    [Fact]
    public void Can_Add_Key_With_Multiple_Unique_Values()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Get("bird").Should().HaveCount(2).And.ContainInOrder("eagle", "sparrow");
    }

    [Fact]
    public void Do_Not_Allow_Duplicate_Value_To_Be_Added_For_A_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "eagle").Should().BeFalse();
        _mvd.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
    }

    [Fact]
    public void Get_When_Key_Does_Not_Exist_Throws()
    {
        Action act = () => _mvd.Get("foo");

        act.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void GetOrDefault_When_Key_Exists_Returns_Values()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.GetOrDefault("bird").Should().HaveCount(2).And.ContainInOrder("eagle", "sparrow");
    }

    [Fact]
    public void GetOrDefault_When_Key_Does_Not_Exist_Returns_Default_Value_For_Type()
    {
        _mvd.GetOrDefault("foo").Should().BeNull();
    }

    [Fact]
    public void Can_Remove_Key_Along_With_Its_Values()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Remove("bird").Should().BeTrue();
        _mvd.GetOrDefault("bird").Should().BeNull();
    }

    [Fact]
    public void Remove_When_Key_Not_Found_Returns_False()
    {
        _mvd.Remove("foo").Should().BeFalse();
    }

    [Fact]
    public void Can_Remove_Value_For_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Remove("bird", "eagle").Should().BeTrue();
        _mvd.Get("bird").Should().ContainSingle().Which.Should().Be("sparrow");
    }

    [Fact]
    public void Remove_Value_When_Value_Does_Not_Exist_Returns_False()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Remove("bird", "sparrow").Should().BeFalse();
        _mvd.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
    }

    [Fact]
    public void Clear_Removes_All_Values_For_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Clear("bird");
        _mvd.Get("bird").Should().BeEmpty();
    }

    [Fact]
    public void Can_Flatten_Dictionary()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Add("cat", "siamese");
        _mvd.Add("cat", "russian blue");

        var keyValuePairs = _mvd.Flatten().ToList();

        keyValuePairs.Should().HaveCount(4);
        keyValuePairs[0].Should().BeEquivalentTo(new KeyValuePair<string, string>("bird", "eagle"));
        keyValuePairs[1].Should().BeEquivalentTo(new KeyValuePair<string, string>("bird", "sparrow"));
        keyValuePairs[2].Should().BeEquivalentTo(new KeyValuePair<string, string>("cat", "siamese"));
        keyValuePairs[3].Should().BeEquivalentTo(new KeyValuePair<string, string>("cat", "russian blue"));
    }

    [Fact]
    public void Can_Union_Two_Dictionaries_Left_Heavy()
    {
        var left = new MultiValueDictionary<string, string> { { "bird", "eagle" }, { "cat", "siamese" } };
        var right = new MultiValueDictionary<string, string> { { "dog", "husky" } };
        var union = left.UnionAll(right);

        union.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
        union.Get("cat").Should().ContainSingle().Which.Should().Be("siamese");
        union.Get("dog").Should().ContainSingle().Which.Should().Be("husky");
    }

    [Fact]
    public void Can_Union_Two_Dictionaries_Right_Heavy()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" }, { "cat", "siamese" } };
        var left = new MultiValueDictionary<string, string> { { "dog", "husky" } };
        var union = left.UnionAll(right);

        union.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
        union.Get("cat").Should().ContainSingle().Which.Should().Be("siamese");
        union.Get("dog").Should().ContainSingle().Which.Should().Be("husky");
    }

    [Fact]
    public void Union_Also_Unions_Values()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" } };
        var union = right.UnionAll(left);

        union.Get("bird").Should().HaveCount(2).And.ContainInOrder("eagle", "sparrow");
    }

    [Fact]
    public void Can_Get_Intersection()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var intersection = right.Intersection(left);
        intersection.Should().HaveCount(1);
        intersection.Get("bird").Should().ContainSingle().Which.Should().Be("eagle");
    }

    [Fact]
    public void Can_Get_Right_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "dog", "husky" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = right.Difference(left);
        difference.Should().HaveCount(2);
        difference.Get("bird").Should().ContainSingle().Which.Should().Be("robin");
        difference.Get("dog").Should().ContainSingle().Which.Should().Be("husky");
    }

    [Fact]
    public void Can_Get_Left_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "dog", "husky" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = left.Difference(right);
        difference.Select(kvp => kvp.Key).Distinct().Should().HaveCount(2);
        difference.Get("bird").Should().HaveCount(2).And.ContainInOrder("sparrow", "eagle");
        difference.Get("cat").Should().ContainSingle().Which.Should().Be("siamese");
    }

    [Fact]
    public void Can_Get_Symmetric_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "bird", "falcon" }, { "dog", "husky" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = right.SymmetricDifference(left);
        difference.Select(kvp => kvp.Key).Distinct().Should().HaveCount(3);
        difference.Get("bird").Should().HaveCount(2).And.ContainInOrder("falcon", "eagle");
        difference.Get("cat").Should().ContainSingle().Which.Should().Be("siamese");
        difference.Get("dog").Should().ContainSingle().Which.Should().Be("husky");
    }
}
