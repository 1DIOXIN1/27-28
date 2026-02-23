using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _coinsView;
    [SerializeField] private CurrencyView _diamondsView;
    [SerializeField] private CurrencyView _energyText;
    
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        _coinsView.Initialize(_wallet.GetValue(Currency.Coin));
        _diamondsView.Initialize(_wallet.GetValue(Currency.Diamond));
        _energyText.Initialize(_wallet.GetValue(Currency.Energy));
    }
}
