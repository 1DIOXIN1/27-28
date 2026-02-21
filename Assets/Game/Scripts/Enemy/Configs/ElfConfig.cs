using System;
using UnityEngine;

[Serializable]
public class ElfConfig : EnemyConfig
{
    [field: SerializeField] public int Mana { get; private set; }
}
