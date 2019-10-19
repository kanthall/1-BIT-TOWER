using UnityEngine;

public class WizardFlame : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 2;
    [SerializeField] GameObject hitPrefab;
    float timeToDestroyProjectiles = 1f;
    
    [SerializeField] AudioClip flameSound;
    [SerializeField] [Range(0, 1)] private float projectileSoundVolume;
    AudioSource audioSource;
 
    void Update()
    {
        Move();
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(flameSound, projectileSoundVolume);

            Destroy(hit, 0.5f); 
        }  
    }
}
