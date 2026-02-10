using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Func<bool> _dieCondition;

    private bool _isDead;
    private float _spawnTime;

    public bool IsDead => _isDead;
    public float LifeTime => Time.time - _spawnTime;

    public void Awake()
    {
        _spawnTime = Time.time;
    }

    public void SetDieCondition(Func<bool> dieCondition)
    {
        _dieCondition = dieCondition;
    }

    public bool ShouldBeDead() => _dieCondition.Invoke();

    public void Die() => _isDead = true;
}
