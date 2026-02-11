using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isDead;
    private float _spawnTime;

    public bool IsDead => _isDead;
    public float LifeTime => Time.time - _spawnTime;

    private void Awake()
    {
        _spawnTime = Time.time;
    }

    public void Die()
    {
        _isDead = true;
    }
}