namespace LeetcodeMsft.Lib.DataStructures;

public static class MultiValueDictionaryExtensions
{
    /// <summary>
    /// Combines the elements of two multi-value dictionaries into a single multi-value dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="this">The source multi-value dictionary.</param>
    /// <param name="other">The multi-value dictionary to combine with.</param>
    /// <returns>A multi-value dictionary that contains all the elements from both input dictionaries.</returns>
    public static IMultiValueDictionary<TKey, TValue> UnionAll<TKey, TValue>(
        this IMultiValueDictionary<TKey, TValue> @this,
        IMultiValueDictionary<TKey, TValue> other)
    {
        foreach (var keyValuePair in other)
        {
            @this.Add(keyValuePair.Key, keyValuePair.Value);
        }

        return @this;
    }

    /// <summary>
    /// Returns a multi-value dictionary that contains the common elements between two multi-value dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="this">The source multi-value dictionary.</param>
    /// <param name="other">The multi-value dictionary to intersect with.</param>
    /// <returns>A multi-value dictionary that contains the common elements between the input dictionaries.</returns>
    /// <remarks>The intersection is determined by comparing the keys and values of the dictionaries.</remarks>
    public static IMultiValueDictionary<TKey, TValue> Intersection<TKey, TValue>(
        this IMultiValueDictionary<TKey, TValue> @this,
        IMultiValueDictionary<TKey, TValue> other) where TKey : notnull
    {
        var intersection = new MultiValueDictionary<TKey, TValue>();

        foreach (var thisKeyValuePair in @this)
        {
            var otherValues = other.GetOrDefault(thisKeyValuePair.Key);

            if (otherValues is null)
            {
                continue;
            }

            if (otherValues.Contains(thisKeyValuePair.Value))
            {
                intersection.Add(thisKeyValuePair.Key, thisKeyValuePair.Value);
            }
        }

        return intersection;
    }

    /// <summary>
    /// Returns a multi-value dictionary that contains the elements from the source dictionary that do not exist in the other dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="this">The source multi-value dictionary.</param>
    /// <param name="other">The multi-value dictionary to compare with.</param>
    /// <returns>A multi-value dictionary that contains the elements from the source dictionary that do not exist in the other dictionary.</returns>
    /// <remarks>The difference is determined by comparing the keys and values of the dictionaries.</remarks>
    public static IMultiValueDictionary<TKey, TValue> Difference<TKey, TValue>(
        this IMultiValueDictionary<TKey, TValue> @this,
        IMultiValueDictionary<TKey, TValue> other) where TKey : notnull
    {
        var difference = new MultiValueDictionary<TKey, TValue>();

        foreach (var thisKeyValuePair in @this)
        {
            var otherValues = other.GetOrDefault(thisKeyValuePair.Key);

            if (otherValues is null)
            {
                difference.Add(thisKeyValuePair.Key, thisKeyValuePair.Value);
            }
            else
            {
                if (!otherValues.Contains(thisKeyValuePair.Value))
                {
                    difference.Add(thisKeyValuePair.Key, thisKeyValuePair.Value);
                }
            }
        }

        return difference;
    }

    /// <summary>
    /// Returns a multi-value dictionary that contains the symmetric difference between two multi-value dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="this">The source multi-value dictionary.</param>
    /// <param name="other">The multi-value dictionary to compare with.</param>
    /// <returns>A multi-value dictionary that contains the symmetric difference between the input dictionaries.</returns>
    /// <remarks>
    /// The symmetric difference is determined by comparing the keys and values of the dictionaries.
    /// The symmetric difference is the set of elements that are in either of the input dictionaries, but not in both.
    /// </remarks>
    public static IMultiValueDictionary<TKey, TValue> SymmetricDifference<TKey, TValue>(
        this IMultiValueDictionary<TKey, TValue> @this,
        IMultiValueDictionary<TKey, TValue> other) where TKey : notnull
    {
        var leftDifference = @this.Difference(other);
        var rightDifference = other.Difference(@this);

        return leftDifference.UnionAll(rightDifference);
    }
}
