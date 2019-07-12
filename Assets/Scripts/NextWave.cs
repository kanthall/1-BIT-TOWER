using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWave : MonoBehaviour
{
    public void spawnNextWave()
    {
         EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].unitsToSpawn = 0;
            enemySpawners[i].spawn = true;
        }
        FindObjectOfType<WaveManager>().AddToWaveCounter();
    }
}
