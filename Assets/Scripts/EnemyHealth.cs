using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] public string unitName;
    [SerializeField] public float startHealth = 100;
    [SerializeField] float health;
    [SerializeField] int scoreValue = 10;

    [Header("Visual & sound")]
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject bloodParticle;
    [SerializeField] AudioClip bloodSound;
    [SerializeField] [Range(0, 1)] float bloodSoundVolume = 0.50f;
    
    [Header("Sound type for hit")]
    [SerializeField] AudioClip punchSound;
    
    [Header("Healthbar")]
    [SerializeField] Image healthBar;

    [Header("Wave modificator")]
    [SerializeField] public bool isLocked;
    private WaveManager waveManager;
    private int waveValue;

    private SteamAchievements steamAchievements;

    AudioSource audioSource;

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveValue = waveManager.GetWave();

        HealthMod();

        health = startHealth;

        audioSource = GetComponent<AudioSource>();

        steamAchievements = FindObjectOfType<SteamAchievements>();
    }

    public void DealDamage(int damage)
    {
        health = health - damage;

        healthBar.fillAmount = health / startHealth;

   //tutaj był dźwięk uderzania

        if (health <= 0)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            ShowDeathParticle();
            ShowBloodParticle();
            Destroy(gameObject);
            FindObjectOfType<ScoreDisplay>().AddToScore(scoreValue);

            PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled") + 1);
            steamAchievements.Unlocking(PlayerPrefs.GetInt("EnemiesKilled", 0));
        }
    }

    private void ShowDeathParticle()
    {
        if (!deathParticle) { return; }
        var deathVfxObject = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(deathVfxObject, 0.5f);
    }
    private void ShowBloodParticle()
    {
        if (!bloodParticle)
        {
            return;
        }
        
        GameObject bloodObject = Instantiate(bloodParticle, transform.position + new Vector3(0, 0, -0.03f), Quaternion.identity);
        audioSource.PlayOneShot(bloodSound, bloodSoundVolume);
        Destroy(bloodObject, 3f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Locker"))
        {
            isLocked = true;
        }
    }

    private void HealthMod()
    {
        if (isLocked == false && waveValue == 2)
        {
            startHealth += 1;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 3)
        {
            startHealth += 3;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 4)
        {
            startHealth += 5;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 5)
        {
            startHealth += 7;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 6)
        {
            startHealth += 9;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 7)
        {
            startHealth += 11;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 8)
        {
            startHealth += 13;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 9)
        {
            startHealth += 15;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 10)
        {
            startHealth += 17;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 11)
        {
            startHealth += 19;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 12)
        {
            startHealth += 21;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 13)
        {
            startHealth += 23;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 14)
        {
            startHealth += 25;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 15)
        {
            startHealth += 27;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 16)
        {
            startHealth += 29;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 17)
        {
            startHealth += 35;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 18)
        {
            startHealth += 40;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 19)
        {
            startHealth += 50;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 20)
        {
            startHealth += 60;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 21)
        {
            startHealth += 70;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 22)
        {
            startHealth += 80;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 23)
        {
            startHealth += 90;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 24)
        {
            startHealth += 100;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 25)
        {
            startHealth += 110;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }
    }
}