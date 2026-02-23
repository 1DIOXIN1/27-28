using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Text _currencyText;

    private IReadOnlyVariable<int> _currency;

    public void Initialize(IReadOnlyVariable<int> currency)
    {
        _currency = currency;

        _currency.Changed += UpdateCurrencyValueText;
    }

    public void UpdateCurrencyValueText(int oldValue, int newValue) => _currencyText.text = newValue.ToString();

    private void OnDestroy()
    {
        _currency.Changed -= UpdateCurrencyValueText;
    }
}
