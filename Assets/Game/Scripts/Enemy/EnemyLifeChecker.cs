using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeChecker : MonoBehaviour
{
    [SerializeField] private int _maxEnemyCount = 3;
    private List<Enemy> _enemyList = new();
    private Dictionary<Enemy, Func<bool>> _deathConditions = new();

    public int MaxEnemyCount => _maxEnemyCount;

    private void Update()
    {
        CheckEnemiesCondition();
        Debug.Log(_enemyList.Count);
    }

    public void RegisterEnemy(Enemy enemy, Func<bool> dieCondition)
    {
        _enemyList.Add(enemy);
        _deathConditions[enemy] = dieCondition;
    }

    public int GetCountEnemy() => _enemyList.Count;

    private void CheckEnemiesCondition()
    {
        for (int i = _enemyList.Count - 1; i >= 0; i--)
        {
            Enemy enemy = _enemyList[i];

            if (_deathConditions.TryGetValue(enemy, out var condition) && condition())
            {
                _deathConditions.Remove(enemy);
                _enemyList.RemoveAt(i);
                Destroy(enemy.gameObject);
            }
        }
    }

    public void RandomEnemyDeath()
    {
        if (_enemyList.Count == 0) return;

        int randomIndex = UnityEngine.Random.Range(0, _enemyList.Count);
        Enemy enemy = _enemyList[randomIndex];

        _deathConditions.Remove(enemy);
        _enemyList.RemoveAt(randomIndex);
        Destroy(enemy.gameObject);
    }
}