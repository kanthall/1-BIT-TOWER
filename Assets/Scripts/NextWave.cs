using UnityEngine;
using UnityEngine.UI;
public class NextWave : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip nextWaveSound;
    [SerializeField] [Range(0, 1)] float nextWaveVolume = 1f;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] private bool spawnAllowed;
    [SerializeField] GameObject button;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
      if (timeBetweenWaves > 0)
      {
          timeBetweenWaves -= Time.deltaTime;
      }

      if (timeBetweenWaves < 0)
      {
          spawnAllowed = true;
          button.GetComponent<Button>().interactable = true;
      }
      SpawnByTheKey();
    }

    public void SpawnNextWave()
    {
        var spawner = FindObjectOfType<EnemySpawner>();
        spawner.spawn = true;
        
        if (spawnAllowed)
        {
            button.GetComponent<Button>().interactable = false;
            
            timeBetweenWaves = 3;
            spawnAllowed = false;
            
            EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();

            audioSource.PlayOneShot(nextWaveSound, nextWaveVolume);

            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].unitsToSpawn = 0;
                enemySpawners[i].spawn = true;
            }
            FindObjectOfType<WaveManager>().AddToWaveCounter();
        }
    }

    private void SpawnByTheKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextWave();
        }
    }
}
