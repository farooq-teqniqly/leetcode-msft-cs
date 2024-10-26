namespace LeetcodeMsft.Lib.DataStructures;

public class MultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, HashSet<TValue>> _dictionary = [];

    public bool Add(TKey key, TValue value)
    {
        if (!_dictionary.TryGetValue(key, out _))
        {
            _dictionary.Add(key, [value]);
            return true;
        }

        _dictionary[key].Add(value);

        return true;
    }

    public bool Remove(TKey key)
    {
        return _dictionary.Remove(key);
    }

    public bool Remove(TKey key, TValue value)
    {
        var values = GetOrDefault(key);

        return values is not null && ((HashSet<TValue>)values).Remove(value);
    }

    public void Clear(TKey key)
    {
        var values = GetOrDefault(key);

        if (values is null)
        {
            return;
        }

        ((HashSet<TValue>)values).Clear();
    }

    public IEnumerable<TValue> Get(TKey key)
    {
        var values = GetOrDefault(key);

        if (values is null)
        {
            throw new KeyNotFoundException();
        }

        return values;
    }

    public IEnumerable<TValue>? GetOrDefault(TKey key)
    {
        return _dictionary.GetValueOrDefault(key);
    }

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
