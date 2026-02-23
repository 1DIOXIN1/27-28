using System;

public interface IReadOnlyVariable<T>
{
    public event Action<T, T> Changed;
    public T Value{ get;}
}
