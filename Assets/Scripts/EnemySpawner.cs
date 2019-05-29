using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemies Types")]
    [SerializeField] GameObject[] enemiesArray;

    [Header("Time")]
    [SerializeField] float minTime = 10f;
    [SerializeField] float maxTime = 15f;

    [SerializeField] public bool spawn = true;
    [SerializeField] public int spawned = 0;

    /*IEnumerator Start()
    {
        while (spawn)
        {

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Spawn();
            spawned++;

            if (spawned >= 1)
            {
                spawn = false;
                break;
            }

        }
    }*/

    void Update()
    {
        while (spawn)
        {
            Spawn();
            spawned++;

            if (spawned >= 1)
            {
                spawn = false;
                break;
            }

        }
    }


    public void Spawn()
    {
        GameObject array = enemiesArray[Random.Range(0, enemiesArray.Length)];

        var newObject = Instantiate(array, transform.position, Quaternion.identity);
        newObject.transform.parent = gameObject.transform;
    }
}