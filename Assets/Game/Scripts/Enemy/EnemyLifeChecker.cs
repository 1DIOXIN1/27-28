using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemyLifeChecker : MonoBehaviour
{
    private int _maxEnemyCount = 3;
    private List<Enemy> _enemyList = new();

    public int MaxEnemyCount => _maxEnemyCount;

    public void Update()
    {
        CheckEnemiesCondition();

        Debug.Log(GetCountEnemy());
    }

    public void RegisterEnemy(Enemy enemy, Func<bool> dieCondition)
    {
        enemy.SetDieCondition(dieCondition);

        _enemyList.Add(enemy);
    }

    public int GetCountEnemy()
    {
        return _enemyList.Count;
    }

    private void CheckEnemiesCondition()
    {
        for (int i = _enemyList.Count - 1; i >= 0; i--)
        {
            Enemy enemy = _enemyList[i];
            if (enemy.ShouldBeDead())
            {
                _enemyList.RemoveAt(i);
                Destroy(enemy.gameObject);
            }
        }
    }

    public void RandomEnemyDeath()
    {
        if (_enemyList.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, _enemyList.Count);
            _enemyList[randomIndex].Die();
        }
    }
}
