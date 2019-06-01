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
    [SerializeField] AudioClip hitSound;

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

        if (health <= 0)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            showDeathParticle();

            Destroy(gameObject);
        }
    }

    private void showDeathParticle()
    {
        if (!deathParticle) { return; }
        GameObject deathVFXObject = Instantiate(deathParticle, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(hitSound);
        Destroy(deathVFXObject, 0.5f);
    }
}