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

        _currencyTextDictionary = new Dictionary<Currency, Text>
        {
            {Currency.Coin, _coinsText},
            {Currency.Diamond, _diamondsText},
            {Currency.Energy, _energyText},
        };

        _wallet.Coins.Changed += OnCoinsChanged;
        _wallet.Energy.Changed += OnEnergyChanged;
        _wallet.Diamond.Changed += OnDiamondChanged;

        UpdateAllCurrencyValueTextAll();
    }

    public void UpdateAllCurrencyValueTextAll()
    {
        foreach (var text in _currencyTextDictionary)
        {
            text.Value.text = _wallet.GetValue(text.Key).Value.ToString();
        }
    }

    private void OnDestroy()
    {
        _wallet.Coins.Changed -= OnCoinsChanged;
        _wallet.Energy.Changed -= OnEnergyChanged;
        _wallet.Diamond.Changed -= OnDiamondChanged;
    }

    private void UpdateCurrencyValueText(Currency currency, int amount)
    {
        _currencyTextDictionary[currency].text = amount.ToString();
    }

    private void OnCoinsChanged(int oldValue, int newValue) => UpdateCurrencyValueText(Currency.Coin, newValue);
    private void OnEnergyChanged(int oldValue, int newValue) => UpdateCurrencyValueText(Currency.Energy, newValue);
    private void OnDiamondChanged(int oldValue, int newValue) => UpdateCurrencyValueText(Currency.Diamond, newValue);
}
