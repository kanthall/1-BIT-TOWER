using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "1BIT/EnemyWaveConfig")]

public class WaveConfig : ScriptableObject
{

    [SerializeField] int enemyHealthMultiplayer;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int waveNumber = 1;
    [SerializeField] List<GameObject> unitsToSpawn = new List<GameObject>();
    [SerializeField] List<Transform> spawners = new List<Transform>();

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

    public int GetWaveNumber()
    {
        return waveNumber;
    }
}
