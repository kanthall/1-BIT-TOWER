using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject wizardProjectile;
    [SerializeField] GameObject wand;

    [SerializeField] float timeBeforeFirstShoot;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1f;

    [Header("Music")]
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.50f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    [Header("Death")]
    [SerializeField] GameObject deathParticle;

    [Header("Animation")]
    [SerializeField] Animator animator;

    //public Transform wizard;
    //public Transform enemy;

    void Start()
    {
        Shooting();
        animator = gameObject.GetComponent<Animator>();
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
        timeBeforeFirstShoot -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeBeforeFirstShoot <= 0f)
            {
                animator.SetTrigger("Shoot");
                Shooting();
                timeBeforeFirstShoot = maxTimeBetweenShots;
            }
        }
    }

    private void Shooting()
    {
        Instantiate(wizardProjectile, wand.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
    }
}

