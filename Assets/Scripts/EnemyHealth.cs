using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
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
        else
        {
            GameObject bloodObject = Instantiate(bloodParticle, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(bloodSound, Camera.main.transform.position, bloodSoundVolume);
            Destroy(bloodObject, 3f);
        }
    }
}