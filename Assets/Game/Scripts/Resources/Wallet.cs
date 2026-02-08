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
    public event Action<Currency, int> OnCurrencyValueChanged;
    private Dictionary<Currency, int> _currencyWallet;

    public Wallet()
    {
        _currencyWallet = new Dictionary<Currency, int>()
        {
            { Currency.Coin, 0 },
            { Currency.Energy, 34 },
            { Currency.Diamond, 151515 },
        };
    }

    public int GetValue(Currency currency)
    {
        return _currencyWallet[currency];
    }

    public void AddValue(Currency currency, int value)
    {
        value = Math.Abs(value);

        _currencyWallet[currency] += value;

        OnCurrencyValueChanged?.Invoke(currency, _currencyWallet[currency]);
    }

    public void RemoveValue(Currency currency, int value)
    {
        value = Math.Abs(value);
        
        _currencyWallet[currency] -= value;

        OnCurrencyValueChanged?.Invoke(currency, _currencyWallet[currency]);
    }
}
