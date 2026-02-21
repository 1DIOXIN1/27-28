using System;
using System.Collections.Generic;

public class ReactiveList<T> 
{
    public Action<T> Added;
    public Action<T> Removed;

    private List<T> _elements = new();

    public IReadOnlyList<T> Elements => _elements;

    public void Add(T element)
    {
        _elements.Add(element);
        Added?.Invoke(element);
    }

    public void Remove(T element)
    {
        _elements.Remove(element);
        Removed?.Invoke(element);
    }
}
