using System;
using System.Collections.Generic;

public enum Currency
{
    Coin,
    Energy,
    Diamond
}

public class Wallet
{
    private ReactiveVariable<int> _coins;
    private ReactiveVariable<int> _energy;
    private ReactiveVariable<int> _diamond;

    private Dictionary<Currency, ReactiveVariable<int>> Currencies = new();

    public Wallet()
    {
        _coins = new ReactiveVariable<int>(0);
        _energy = new ReactiveVariable<int>(34);
        _diamond = new ReactiveVariable<int>(151515);

        Currencies.Add(Currency.Coin, _coins);
        Currencies.Add(Currency.Energy, _energy);
        Currencies.Add(Currency.Diamond, _diamond);
    }

    public IReadOnlyVariable<int> GetValue(Currency currency)
    {
        return Currencies[currency];
    }

    public void AddValue(Currency currency, int value)
    {
        value = Math.Abs(value);

        Currencies[currency].Value += value;
    }

    public void RemoveValue(Currency currency, int value)
    {
        value = Math.Abs(value);
        
        if (Currencies[currency].Value - value <= 0)
            Currencies[currency].Value = 0;
        else
            Currencies[currency].Value -= value;
    }
}
