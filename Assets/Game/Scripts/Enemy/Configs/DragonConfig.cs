using System;
using UnityEngine;

[Serializable]
public class DragonConfig : EnemyConfig
{
    [field: SerializeField] public int Agility { get; private set; }
}