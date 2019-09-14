using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float waveSpeedModicifator;
    [SerializeField] public float enemyMoveSpeed = 0.5f;
    [SerializeField] public bool isMoving = true;

    void Start()
    {
        waveSpeedModicifator = 0.7f;
    }

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(waveSpeedModicifator * Time.deltaTime * enemyMoveSpeed * Vector3.left);
    }

    private void WavesDiff()
    {
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
}
