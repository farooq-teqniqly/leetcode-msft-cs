namespace LeetcodeMsft.Lib.DataStructures;

/// <summary>
/// Represents a dictionary that allows multiple values to be associated with a single key.
/// </summary>
/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
public class MultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, HashSet<TValue>> _dictionary = [];

    /// <inheritdoc />
    public bool Add(TKey key, TValue value)
    {
        if (!_dictionary.TryGetValue(key, out _))
        {
            _dictionary.Add(key, [value]);
            return true;
        }

        return _dictionary[key].Add(value);
    }

    /// <inheritdoc />
    public bool Remove(TKey key)
    {
        return _dictionary.Remove(key);
    }

    /// <inheritdoc />
    public bool Remove(TKey key, TValue value)
    {
        var values = GetOrDefault(key);

        return values is not null && ((HashSet<TValue>)values).Remove(value);
    }

    /// <inheritdoc />
    public void Clear(TKey key)
    {
        if (_dictionary.TryGetValue(key, out var values))
        {
            values.Clear();
        }
    }

    /// <inheritdoc />
    public IEnumerable<TValue> Get(TKey key)
    {
        var values = GetOrDefault(key);

        if (values is null)
        {
            throw new KeyNotFoundException();
        }

        return values;
    }

    /// <inheritdoc />
    public IEnumerable<TValue>? GetOrDefault(TKey key)
    {
        return _dictionary.GetValueOrDefault(key);
    }

    /// <inheritdoc />
    public IEnumerable<KeyValuePair<TKey, TValue>> Flatten()
    {
        foreach (var key in _dictionary.Keys)
        {
            foreach (var value in _dictionary[key])
            {
                yield return new KeyValuePair<TKey, TValue>(key, value);
            }
        }
    }
}
