using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float startHealth = 100;
    [SerializeField] float health;
    [SerializeField] int scoreValue = 150;

    [Header("Visual & sound")]
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject bloodParticle;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip bloodSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.50f;

    [Header("Healthbar")]
    [SerializeField] Image healthBar;

    AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = startHealth;
    }

    public void DealDamage(int damage)
    {
        health = health - damage;

        healthBar.fillAmount = health / startHealth;

        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, projectileSoundVolume);

        if (health <= 0)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            showDeathParticle();
            showBloodParticle();
            Destroy(gameObject);
        }
    }

    private void showDeathParticle()
    {
        if (!deathParticle) { return; }
        GameObject deathVFXObject = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 0.5f);
    }

    private void showBloodParticle()
    {
        if (!bloodParticle)
        {
            return;
        }
        else
        {
            Debug.Log("udalo sie");
            GameObject bloodObject = Instantiate(bloodParticle, transform.position, Quaternion.identity);
            //audioSource.PlayOneShot(bloodSound);
            AudioSource.PlayClipAtPoint(bloodSound, Camera.main.transform.position, projectileSoundVolume);
            Destroy(bloodObject, 3f);
        }
    }
}