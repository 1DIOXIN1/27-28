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
    public event Action<Currency, int> CurrencyValueChanged;
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

        CurrencyValueChanged?.Invoke(currency, _currencyWallet[currency]);
    }

    public void RemoveValue(Currency currency, int value)
    {
        value = Math.Abs(value);
        
        if (_currencyWallet[currency] - value <= 0)
            _currencyWallet[currency] = 0;
        else
            _currencyWallet[currency] -= value;

        CurrencyValueChanged?.Invoke(currency, _currencyWallet[currency]);
    }
}
