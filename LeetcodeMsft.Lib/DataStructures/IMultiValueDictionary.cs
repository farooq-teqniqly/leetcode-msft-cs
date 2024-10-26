namespace LeetcodeMsft.Lib.DataStructures;

/// <summary>
/// Represents a dictionary that allows multiple values to be associated with a single key.
/// </summary>
/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
public interface IMultiValueDictionary<TKey, TValue>
{
    /// <summary>
    /// Adds a value to the multi-value dictionary.
    /// </summary>
    /// <param name="key">The key to add the value to.</param>
    /// <param name="value">The value to add.</param>
    /// <returns>True if the value was added successfully, false otherwise.</returns>
    bool Add(TKey key, TValue value);

    /// <summary>
    /// Removes a key and all its associated values from the multi-value dictionary.
    /// </summary>
    /// <param name="key">The key to remove.</param>
    /// <returns>True if the key was found and removed successfully, false otherwise.</returns>
    bool Remove(TKey key);

    /// <summary>
    /// Removes a specific value associated with a key from the multi-value dictionary.
    /// </summary>
    /// <param name="key">The key to remove the value from.</param>
    /// <param name="value">The value to remove.</param>
    /// <returns>True if the value was found and removed successfully, false otherwise.</returns>
    bool Remove(TKey key, TValue value);

    /// <summary>
    /// Removes all values associated with a key from the multi-value dictionary.
    /// </summary>
    /// <param name="key">The key to clear.</param>
    void Clear(TKey key);

    /// <summary>
    /// Gets all values associated with a key from the multi-value dictionary.
    /// </summary>
    /// <param name="key">The key to get the values for.</param>
    /// <returns>An enumerable collection of values associated with the key.</returns>
    IEnumerable<TValue> Get(TKey key);

    /// <summary>
    /// Gets all values associated with a key from the multi-value dictionary, or returns an empty collection if the key is not found.
    /// </summary>
    /// <param name="key">The key to get the values for.</param>
    /// <returns>An enumerable collection of values associated with the key, or an empty collection if the key is not found.</returns>
    IEnumerable<TValue>? GetOrDefault(TKey key);

    /// <summary>
    /// Flattens the multi-value dictionary into a collection of key-value pairs.
    /// </summary>
    /// <returns>An enumerable collection of key-value pairs representing the multi-value dictionary.</returns>
    IEnumerable<KeyValuePair<TKey, TValue>> Flatten();
}
