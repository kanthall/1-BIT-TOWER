using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardProjectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 2;
    [SerializeField] GameObject hitPrefab;
    float timeToDestroyProjectiles = 1f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Time.deltaTime * projectileSpeed * Vector3.right);
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

            var hit = Instantiate(hitPrefab, health.transform.position, Quaternion.identity);
            Destroy(hit, 0.5f); 
        }  
    }
}
