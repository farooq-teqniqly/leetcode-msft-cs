using FluentAssertions;
using LeetcodeMsft.Lib.DataStructures;

namespace LeetcodeMsft.Lib.Tests.DataStructures;
public class MultiValueDictionaryTests
{
    private readonly MultiValueDictionary<string, string> _mvd = [];

    [Fact]
    public void Can_Add_Key_With_Single_Value()
    {
        _mvd.Add("bird", "eagle").Should().Be(true);
        _mvd.Get("bird").Count().Should().Be(1);
        _mvd.Get("bird").First().Should().Be("eagle");
    }

    [Fact]
    public void Can_Add_Key_With_Multiple_Unique_Values()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Get("bird").Count().Should().Be(2);
        _mvd.Get("bird").First().Should().Be("eagle");
        _mvd.Get("bird").Skip(1).First().Should().Be("sparrow");
    }

    [Fact]
    public void Do_Not_Allow_Duplicate_Value_To_Be_Added_For_A_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "eagle").Should().BeFalse();
        _mvd.Get("bird").Count().Should().Be(1);
        _mvd.Get("bird").First().Should().Be("eagle");
    }

    [Fact]
    public void Get_When_Key_Does_Not_Exist_Throws()
    {
        var act = () => _mvd.Get("foo");

        act.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void GetOrDefault_When_Key_Exists_Returns_Values()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.GetOrDefault("bird")!.Count().Should().Be(2);
        _mvd.GetOrDefault("bird")!.First().Should().Be("eagle");
        _mvd.GetOrDefault("bird")!.Skip(1).First().Should().Be("sparrow");
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
        _mvd.Remove("bird").Should().Be(true);
        _mvd.GetOrDefault("bird").Should().BeNull();
    }

    [Fact]
    public void Remove_When_Key_Not_Found_Returns_False()
    {
        _mvd.Remove("foo").Should().Be(false);
    }

    [Fact]
    public void Can_Remove_Value_For_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Remove("bird", "eagle").Should().Be(true);
        _mvd.Get("bird").Count().Should().Be(1);
        _mvd.Get("bird").First().Should().Be("sparrow");
    }

    [Fact]
    public void Remove_Value_When_Value_Does_Not_Exist_Returns_False()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Remove("bird", "sparrow").Should().Be(false);
        _mvd.Get("bird").Count().Should().Be(1);
        _mvd.Get("bird").First().Should().Be("eagle");
    }

    [Fact]
    public void Clear_Removes_All_Values_For_Key()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Clear("bird");
        _mvd.Get("bird").Count().Should().Be(0);
    }

    [Fact]
    public void Can_Flatten_Dictionary()
    {
        _mvd.Add("bird", "eagle");
        _mvd.Add("bird", "sparrow");
        _mvd.Add("cat", "siamese");
        _mvd.Add("cat", "russian blue");

        var keyValuePairs = _mvd.Flatten().ToList();

        keyValuePairs.Count.Should().Be(4);

        keyValuePairs.First().Should().BeEquivalentTo(new KeyValuePair<string, string>("bird", "eagle"));

        keyValuePairs.Skip(1).First().Should().BeEquivalentTo(new KeyValuePair<string, string>("bird", "sparrow"));

        keyValuePairs.Skip(2).First().Should().BeEquivalentTo(new KeyValuePair<string, string>("cat", "siamese"));

        keyValuePairs.Skip(3).First().Should().BeEquivalentTo(new KeyValuePair<string, string>("cat", "russian blue"));
    }

    [Fact]
    public void Can_Union_Two_Dictionaries_Left_Heavy()
    {
        var left = new MultiValueDictionary<string, string> { { "bird", "eagle" }, { "cat", "siamese" } };
        var right = new MultiValueDictionary<string, string> { { "dog", "husky" } };
        var union = left.UnionAll(right);

        union.Get("bird").Count().Should().Be(1);
        union.Get("bird").First().Should().Be("eagle");
        union.Get("cat").Count().Should().Be(1);
        union.Get("cat").First().Should().Be("siamese");
        union.Get("dog").Count().Should().Be(1);
        union.Get("dog").First().Should().Be("husky");
    }

    [Fact]
    public void Can_Union_Two_Dictionaries_Right_Heavy()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" }, { "cat", "siamese" } };
        var left = new MultiValueDictionary<string, string> { { "dog", "husky" } };
        var union = left.UnionAll(right);

        union.Get("bird").Count().Should().Be(1);
        union.Get("bird").First().Should().Be("eagle");
        union.Get("cat").Count().Should().Be(1);
        union.Get("cat").First().Should().Be("siamese");
        union.Get("dog").Count().Should().Be(1);
        union.Get("dog").First().Should().Be("husky");
    }

    [Fact]
    public void Union_Also_Unions_Values()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" }};
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" } };
        var union = right.UnionAll(left);

        union.Get("bird").Count().Should().Be(2);
        union.Get("bird").First().Should().Be("eagle");
        union.Get("bird").Skip(1).First().Should().Be("sparrow");
    }

    [Fact]
    public void Can_Get_Intersection()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "eagle" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, {"cat", "siamese"} };

        var intersection = right.Intersection(left);
        intersection.Count().Should().Be(1);

        intersection.Get("bird").Count().Should().Be(1);
        intersection.Get("bird").First().Should().Be("eagle");
    }

    [Fact]
    public void Can_Get_Right_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, {"dog", "husky"} };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = right.Difference(left);
        difference.Count().Should().Be(2);

        difference.Get("bird").Count().Should().Be(1);
        difference.Get("bird").First().Should().Be("robin");
        difference.Get("dog").Count().Should().Be(1);
        difference.Get("dog").First().Should().Be("husky");
    }

    [Fact]
    public void Can_Get_Left_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "dog", "husky" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "sparrow" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = left.Difference(right);
        difference.Select(kvp => kvp.Key).Distinct().Count().Should().Be(2);

        difference.Get("bird").Count().Should().Be(2);
        difference.Get("bird").First().Should().Be("sparrow");
        difference.Get("bird").Skip(1).First().Should().Be("eagle");
        difference.Get("cat").Count().Should().Be(1);
        difference.Get("cat").First().Should().Be("siamese");
    }

    [Fact]
    public void Can_Get_Symmetric_Difference()
    {
        var right = new MultiValueDictionary<string, string> { { "bird", "robin" }, {"bird", "falcon"}, { "dog", "husky" } };
        var left = new MultiValueDictionary<string, string> { { "bird", "robin" }, { "bird", "eagle" }, { "cat", "siamese" } };

        var difference = right.SymmetricDifference(left);
        difference.Select(kvp => kvp.Key).Distinct().Count().Should().Be(3);

        difference.Get("bird").Count().Should().Be(2);
        difference.Get("bird").First().Should().Be("falcon");
        difference.Get("bird").Skip(1).First().Should().Be("eagle");
        difference.Get("cat").Count().Should().Be(1);
        difference.Get("cat").First().Should().Be("siamese");
        difference.Get("dog").Count().Should().Be(1);
        difference.Get("dog").First().Should().Be("husky");
    }
}
