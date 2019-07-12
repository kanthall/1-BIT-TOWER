using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "1BIT/EnemyWaveConfig")]

public class WaveConfig : ScriptableObject
{

    [SerializeField] int enemyHealthMultiplayer;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;

    public float GetEnemyHealthMultiplayer()
    {
        return enemyHealthMultiplayer;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
