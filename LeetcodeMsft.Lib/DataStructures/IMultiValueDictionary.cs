namespace LeetcodeMsft.Lib.DataStructures;
public interface IMultiValueDictionary<TKey, TValue>
{
    bool Add(TKey key, TValue value);
    bool Remove(TKey key);
    bool Remove(TKey key, TValue value);
    void Clear(TKey key);

    IEnumerable<TValue> Get(TKey key);

    IEnumerable<TValue>? GetOrDefault(TKey key);

    IEnumerable<KeyValuePair<TKey, TValue>> Flatten();
}
