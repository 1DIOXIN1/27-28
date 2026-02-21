using System;
using UnityEngine;

[Serializable]
public class EnemyConfig
{
    [field: SerializeField] public GameObject Prefab { get; private set;}
}
