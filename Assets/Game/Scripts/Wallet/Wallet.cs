using System;

public enum Currency
{
    Coin,
    Energy,
    Diamond
}

public class Wallet
{
    public ReactiveVariable<int> Coins;
    public ReactiveVariable<int> Energy;
    public ReactiveVariable<int> Diamond;
    public ReactiveDictionary<Currency, ReactiveVariable<int>> CurrencyWallet = new();

    public Wallet()
    {
        Coins = new ReactiveVariable<int>(0);
        Energy = new ReactiveVariable<int>(34);
        Diamond = new ReactiveVariable<int>(151515);

        CurrencyWallet.Add(Currency.Coin, Coins);
        CurrencyWallet.Add(Currency.Energy, Energy);
        CurrencyWallet.Add(Currency.Diamond, Diamond);
    }

    public ReactiveVariable<int> GetValue(Currency currency)
    {
        return CurrencyWallet.Elements[currency];
    }

    public void AddValue(Currency currency, int value)
    {
        value = Math.Abs(value);

        CurrencyWallet.Elements[currency].Value += value;
    }

    public void RemoveValue(Currency currency, int value)
    {
        value = Math.Abs(value);
        
        if (CurrencyWallet.Elements[currency].Value - value <= 0)
            CurrencyWallet.Elements[currency].Value = 0;
        else
            CurrencyWallet.Elements[currency].Value -= value;
    }
}
