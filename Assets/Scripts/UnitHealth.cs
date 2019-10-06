using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [Header("Health")]
    float health = 100;
    [SerializeField] public float startHealth;
 
    [Header("Healthbar")]
    [SerializeField] Image healthBar;

    [Header("Death")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] GameObject deathParticle;
    [SerializeField] public string unitName;

    private AudioSource audioSource;
    private GameObject parent;

    private void Start()
    {
        health = startHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            gameObject.SetActive(false);

            parent = transform.parent.gameObject;
            transform.parent = null;
            Destroy(parent);

            GameObject death = Instantiate(deathParticle, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(deathSound, 1F);
            Destroy(death, 3f);
        }
    }
}