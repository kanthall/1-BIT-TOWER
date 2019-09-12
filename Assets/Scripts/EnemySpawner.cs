using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemies Types")]
    [SerializeField] GameObject[] enemiesArray;

    [Header("Time")]
    [SerializeField] float timeBeforeSpawn;
    [SerializeField] float time;

    [Header("Spawn")]
    [SerializeField] public bool spawn = false;
    [SerializeField] public int unitsToSpawn;

    private void Start()
    {
        timeBeforeSpawn = time;
    }

    void Update()
    {
        CountDownAndSpawn(); 
    }

    public void CountDownAndSpawn()
    {
        if (spawn)
        {
            time -= Time.deltaTime;

            if (time <= 0f)
            {
                Spawn();
                unitsToSpawn++;
                time = timeBeforeSpawn;

                if (unitsToSpawn == 1)
                {
                    spawn = false;
                }
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