using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items;
    private int _maxSize;

    public Inventory(List<Item> initialItems, int maxSize)
    {
        if (maxSize <= 0)
            throw new ArgumentException(nameof(maxSize), "Максимальный размер должен быть положительным");

        if (initialItems == null)
            throw new ArgumentNullException(nameof(initialItems));

        _items = new List<Item>();
        _maxSize = maxSize;

        foreach (var item in initialItems)
        {
            if (item == null) continue;

            if (CurrentSize + item.Count > maxSize)
                throw new InvalidOperationException("Начальные предметы превышают вместимость инвентаря");

            _items.Add(item);
        }
    }
    
    public int MaxSize => _maxSize;
    public int CurrentSize => _items.Sum(item => item.Count);
    public IReadOnlyList<Item> Items => _items;

    public bool TryAdd(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        if (item.Count <= 0)
            throw new ArgumentException(nameof(item), "Количество предмета должно быть положительным");

        if (CurrentSize + item.Count > MaxSize)
            return false;

        _items.Add(item);

        return true;
    }

    public bool CanTakeItems(string name, int count)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Передано отрицательное значение");

        int totalAvailable = _items.Where(item => item.Name == name).Sum(item => item.Count);
        
        return totalAvailable >= count;
    }

    public List<Item> TakeItems(string name, int count)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Передано отрицательное значение");

        if(CanTakeItems(name, count) == false)
            return new List<Item>();

        var taken = new List<Item>();
        int remaining = count;

        for (int i = _items.Count - 1; i >= 0 && remaining > 0; i--)
        {
            var item = _items[i];

            if (item.Name != name) continue;

            if (item.Count <= remaining)
            {
                taken.Add(new Item(name, item.Count));
                remaining -= item.Count;
                _items.RemoveAt(i);
            }
            else
            {
                taken.Add(new Item(item.Name, remaining));
                item.Reduce(remaining);
                remaining = 0;
            }
        }

        return taken;
    }
}

public class Item
{
    public Item(string name, int startCount)
    {
        Name = name;

        if(startCount < 0)
            throw new ArgumentOutOfRangeException(nameof(startCount), "Передано отрицательное значение");

        Count = startCount;
    }
    public string Name { get; private set;}
    public int Count { get; private set; }

    public void Add(int count)
    {
        if(count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Передано отрицательное значение");

        Count += count;
    }

    public void Reduce(int count)
    {
        if(count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Передано отрицательное значение");
        
        if (count > Count)
            throw new InvalidOperationException("Недостаточно предметов для уменьшения");

        Count -= count;
    }
}