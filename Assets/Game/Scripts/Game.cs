using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerSliderView _timerSliderView;
    [SerializeField] private TimerHeartsView _timerHeartsView;
    [SerializeField] private TimerControls _timerControls;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private EnemyLifeChecker _enemyLifeChecker;

    private Wallet _wallet;
    private Timer _timer;

    private void Awake() => Initialization();

    private void Update() => KeyBoardInput();

    private void Initialization()
    {
        _wallet = new Wallet();
        _timer = new Timer(this);

        _walletView.Initialize(_wallet);
        _timerSliderView.Initialize(_timer);
        _timerHeartsView.Initialize(_timer);
        _timerControls.Initialize(_timer);
    }

    private void KeyBoardInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            _enemyLifeChecker.RegisterEnemy(enemy, () => enemy.IsDead);
            Debug.Log("Создан враг с условием IsDead");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            _enemyLifeChecker.RegisterEnemy(enemy, () => enemy.LifeTime > 5f);
            Debug.Log("Создан враг с условием LifeTime > 5f");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            _enemyLifeChecker.RegisterEnemy(enemy, () => _enemyLifeChecker.GetCountEnemy() > _enemyLifeChecker.MaxEnemyCount);
            Debug.Log("Создан враг с условием MaxEnemyCount");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _enemyLifeChecker.RandomEnemyDeath();
        }
    }
}