using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextWave : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip nextWaveSound;
    [SerializeField] [Range(0, 1)] float nextWaveVolume = 1f;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        NextWaveKey();
    }
    
    public void SpawnNextWave()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

        audioSource.PlayOneShot(nextWaveSound, nextWaveVolume);
        
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
