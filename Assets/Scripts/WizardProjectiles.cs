﻿using UnityEngine;

public class WizardProjectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] public int damage = 2;
    float timeToDestroyProjectiles = 1f;
    [SerializeField] private GameObject hitPrefab;
    
    [SerializeField] AudioClip projectileHitSound;
    [SerializeField] [Range(0, 1)] private float projectileSoundVolume;
    AudioSource audioSource;

    void Update()
    {
        Move();
        audioSource = GetComponent<AudioSource>();
    }

    private void Move()
    {
        transform.Translate( Time.deltaTime * projectileSpeed * Vector3.right);
        Destroy(gameObject, timeToDestroyProjectiles);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<EnemyHealth>();
        var attacker = otherCollider.GetComponent<EnemyMovement>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
            audioSource.PlayOneShot(projectileHitSound, projectileSoundVolume);

            var hit = Instantiate(hitPrefab, health.transform.position, Quaternion.identity);
            Destroy(hit, 1f); 
        }
    }
}
