using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerView _timerView;

    private Wallet _wallet;
    private Timer _timer;

    private void Awake() => Initialization();

    private void Initialization()
    {
        _wallet = new Wallet();
        _timer = new Timer(this);
        
        _timerView.Initialize(_timer);
        _walletView.Initialize(_wallet);
    }
}
