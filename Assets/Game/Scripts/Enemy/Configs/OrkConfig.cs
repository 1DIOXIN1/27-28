using System;
using UnityEngine;

[Serializable]
public class OrkConfig : EnemyConfig
{
    [field: SerializeField] public int Damage { get; private set; }
}