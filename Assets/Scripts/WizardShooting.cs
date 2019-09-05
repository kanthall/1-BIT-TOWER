using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardShooting : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject wizardProjectile;
    [SerializeField] GameObject wand;

    [SerializeField] float timeBeforeFirstShoot;
    [SerializeField] float timeBetweenShots = 1f;

    [Header("Music")]
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] float projectileSoundVolume = 0.50f;

    [Header("Animation")]
    [SerializeField] Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timeBeforeFirstShoot -= Time.deltaTime;

            if (timeBeforeFirstShoot <= 0f)
            {
                Shooting();
                animator.SetTrigger("Shoot");
                Debug.Log("shoot");
                timeBeforeFirstShoot = timeBetweenShots;
            }
            else
            {
                animator.ResetTrigger("Shoot");
            }
        } 
    }

    private void Shooting()
    {
        Instantiate(wizardProjectile, wand.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
    }
}

