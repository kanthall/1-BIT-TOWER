using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextWave : MonoBehaviour
{
    private void Update()
    {
        NextWaveKey();
    }
    
    public void SpawnNextWave()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].unitsToSpawn = 0;
            enemySpawners[i].spawn = true;
        }
        FindObjectOfType<WaveManager>().AddToWaveCounter();
    }
    
    private void NextWaveKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextWave();
        }
        else
        {
            return;
        }
    }
}
