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
        var next = FindObjectOfType<EnemySpawner>();

        var test = GameObject.FindGameObjectsWithTag("Spawner");

        next.spawned = 0;
        next.spawn = true;
    }
}
