using System;
using System.Collections.Generic;

public class ReactiveDictionary<TKey, TValue>
{
    public Action<TKey, TValue> Added;
    public Action<TKey, TValue> Removed;

    private Dictionary<TKey, TValue> _elements = new();

    public IReadOnlyDictionary<TKey, TValue> Elements => _elements;

    public void Add(TKey key, TValue value)
    {
        _elements.Add(key, value);
        Added?.Invoke(key, value);
    }

    public void Remove(TKey key)
    {
        Removed?.Invoke(key, _elements[key]);
        _elements.Remove(key);
    }
}