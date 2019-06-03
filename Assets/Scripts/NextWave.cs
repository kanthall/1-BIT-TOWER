using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWave : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void spawnNextWave()
    {
        /*var next = FindObjectsOfType<EnemySpawner>();
        
        //var test = GameObject.FindGameObjectsWithTag("Spawner");

        for (int i = 0; i < next.Length; i++)
            {
            next[i].unitsToSpawn = 0;
            next[i].spawn = true;
        }
        */

        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].unitsToSpawn = 0;
            enemySpawners[i].spawn = true;
        }
    }
}
