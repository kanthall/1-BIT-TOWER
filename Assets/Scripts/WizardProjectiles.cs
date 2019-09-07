using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WizardProjectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 2;
    float timeToDestroyProjectiles = 1f;
    [SerializeField] private GameObject hitPrefab;
    
    [SerializeField] AudioClip projectileSound;
    [SerializeField] [Range(0, 1)] private float projectileSoundVolume;

    void Update()
    {
        Move();
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
            AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position, projectileSoundVolume);
            
            var hit = Instantiate(hitPrefab, health.transform.position, Quaternion.identity);
            Destroy(hit, 0.5f); 
        }
    }
}
