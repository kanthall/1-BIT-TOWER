using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "1BIT/EnemyWaveConfig")]

public class WaveConfig : ScriptableObject
{

    [SerializeField] int enemyHealthMultiplayer;
    [SerializeField] List<GameObject> unitsToSpawn = new List<GameObject>();
    [SerializeField] List<Transform> spawners = new List<Transform>();

    public float GetEnemyHealthMultiplayer()
    {
        return enemyHealthMultiplayer;
    }
}
