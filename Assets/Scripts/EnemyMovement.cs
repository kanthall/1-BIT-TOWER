using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float waveSpeedModicifator;
    [SerializeField] float enemyMoveSpeed = 0.5f;

    void Start()
    {
        waveSpeedModicifator = 0.7f;
    }

    void Update()
    {
        Move();

            if (FindObjectOfType<WaveManager>().GetWave() > 5)
            {
                waveSpeedModicifator = 0.85f;
            }

            if (FindObjectOfType<WaveManager>().GetWave() > 10)
            {
                waveSpeedModicifator = 0.95f;
            }

            if (FindObjectOfType<WaveManager>().GetWave() > 15)
            {
                waveSpeedModicifator = 1.02f;
            }
    }

    private void Move()
    {   
        transform.Translate(Vector3.left * Time.deltaTime * enemyMoveSpeed * waveSpeedModicifator);
    }
}
