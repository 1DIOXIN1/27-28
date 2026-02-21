using System;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public void Spawn(EnemyConfig config, Vector3 spawnPoint)
    {
        switch (config)
        {
            case OrkConfig orkConfig:
                {
                    GameObject enemy = Instantiate(orkConfig.Prefab, spawnPoint, Quaternion.identity);
                    enemy.GetComponent<Enemy>().Initialization(orkConfig);
                    Debug.Log($"Заспавнился {enemy.name} c Damage {orkConfig.Damage}");
                    break;
                }
            
            case ElfConfig elfConfig:
                {
                    GameObject enemy = Instantiate(elfConfig.Prefab, spawnPoint, Quaternion.identity);
                    enemy.GetComponent<Enemy>().Initialization(elfConfig);
                    Debug.Log($"Заспавнился {enemy.name} c mana {elfConfig.Mana}");
                    break;
                }

            case DragonConfig dragonConfig:
                {
                    GameObject enemy = Instantiate(dragonConfig.Prefab, spawnPoint, Quaternion.identity);
                    enemy.GetComponent<Enemy>().Initialization(dragonConfig);
                    Debug.Log($"Заспавнился {enemy.name} c agility {dragonConfig.Agility}");
                    break;
                }
            
            default: 
                throw new ArgumentException("Нет врага с таким конфигом");
        }
    }
}
