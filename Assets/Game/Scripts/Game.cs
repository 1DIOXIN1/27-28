using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerSliderView _timerSliderView;
    [SerializeField] private TimerHeartsView _timerHeartsView;
    [SerializeField] private TimerControls _timerControls;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EnemiesSpawner _enemySpawner;
    [SerializeField] private OrkConfig[] _orkConfigs;
    [SerializeField] private ElfConfig[] _elfConfigs;
    [SerializeField] private DragonConfig[] _dragonConfigs;

    private Wallet _wallet;
    private Timer _timer;

    private void Awake()
    {
        Initialization();

        foreach (var config in _orkConfigs)
            _enemySpawner.Spawn(config, GetRandomPoint());
        
        foreach (var config in _elfConfigs)
            _enemySpawner.Spawn(config, GetRandomPoint());
        
        foreach (var config in _dragonConfigs)
            _enemySpawner.Spawn(config, GetRandomPoint());
    }

    private void Initialization()
    {
        _wallet = new Wallet();
        _timer = new Timer(this);

        _walletView.Initialize(_wallet);
        _timerSliderView.Initialize(_timer);
        _timerHeartsView.Initialize(_timer);
        _timerControls.Initialize(_timer);
    }

    private Vector3 GetRandomPoint() => _spawnPoint.position * Random.insideUnitCircle;
}