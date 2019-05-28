using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_next_wave : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void spawnNextWave()
    {
        var next = FindObjectOfType<Script_enemy_spawner>();

        var test = GameObject.FindGameObjectsWithTag("Spawner");

        next.spawned = 0;
        next.spawn = true;
    }
}
