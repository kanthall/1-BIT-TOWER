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
    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveValue = waveManager.GetWave();

        HealthMod();

        health = startHealth;
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
        
        GameObject bloodObject = Instantiate(bloodParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(bloodSound, Camera.main.transform.position, bloodSoundVolume);
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
            startHealth += 6;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }
        
        if (isLocked == false && waveValue == 6)
        {
            startHealth += 8;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }
        
        if (isLocked == false && waveValue == 7)
        {
            startHealth += 9;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 8)
        {
            startHealth += 11;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 9)
        {
            startHealth += 12;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 10)
        {
            startHealth += 14;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 11)
        {
            startHealth += 16;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 12)
        {
            startHealth += 17;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue == 13)
        {
            startHealth += 19;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }

        if (isLocked == false && waveValue >= 14)
        {
            startHealth += 22;
            FindObjectOfType<WaveCanvas>().ShowWarning();
        }
    }
}