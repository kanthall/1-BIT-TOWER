using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_wizard_shooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject wizardProjectile;
    [SerializeField] GameObject wand;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Music")]
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.50f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    [Header("Death")]
    [SerializeField] GameObject deathParticle;

    public Transform wizard;
    public Transform enemy;

    void Start()
    {
        Shooting();
       // wizard = GameObject.FindGameObjectWithTag("Wizard").transform;
       // enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        /*float differenceY = System.Math.Abs(wizard.transform.position.y - enemy.transform.position.y);

        Debug.Log(differenceY);

        if ((differenceY) < 0.17f)
        {
            CountDownAndShoot();
        }
        else
        {
           return;
        }*/

        CountDownAndShoot();
    }
      
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Shooting();
            shotCounter = maxTimeBetweenShots;
        }
    }

    private void Shooting()
    {
        Instantiate(wizardProjectile, wand.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
    }
}

