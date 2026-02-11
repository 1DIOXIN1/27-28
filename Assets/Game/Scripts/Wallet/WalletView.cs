using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _diamondsText;
    [SerializeField] private Text _energyText;

    private Dictionary<Currency, Text> _currencyTextDictionary;
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.CurrencyValueChanged += UpdateCurrencyValueText;

        _currencyTextDictionary = new Dictionary<Currency, Text>
        {
            {Currency.Coin, _coinsText},
            {Currency.Diamond, _diamondsText},
            {Currency.Energy, _energyText},
        };

        UpdateAllCurrencyValueTextAll();
    }

    public void UpdateAllCurrencyValueTextAll()
    {
        foreach (Currency currency in _currencyTextDictionary.Keys)
        {
            _currencyTextDictionary[currency].text = _wallet.GetValue(currency).ToString();
        }
    }

    private void UpdateCurrencyValueText(Currency currency, int amount)
    {
        _currencyTextDictionary[currency].text = amount.ToString();
    }
}
