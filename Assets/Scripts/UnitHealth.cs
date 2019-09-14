using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [Header("Health")]
    float health = 100;
    [SerializeField] float startHealth;
 
    [Header("Healthbar")]
    [SerializeField] Image healthBar;

    [Header("Death")]
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] GameObject deathParticle;

    private void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            gameObject.SetActive(false);

            GameObject death = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(death, 3f);
            //audioSource.PlayOneShot(deathSound, 1F);
        
        }
    }
}