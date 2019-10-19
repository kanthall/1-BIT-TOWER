using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float firstAttackTime;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] [Range(0, 1)] float attackSoundVolume = 0.50f;
    [SerializeField] public int attackPower;
    [SerializeField] GameObject attackParticle;
    AudioSource audioSource;
    
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            firstAttackTime -= Time.deltaTime;

            if (firstAttackTime <= 0f)
            {
                firstAttackTime = timeBetweenAttacks;

                animator.SetTrigger("Attack");

                var health = collision.GetComponent<EnemyHealth>();
                var attacker = collision.GetComponent<EnemyMovement>();

                if (health && attacker)
                {
                    health.DealDamage(attackPower);
                    audioSource.PlayOneShot(attackSound, attackSoundVolume);
                    var hit = Instantiate(attackParticle, attacker.transform.position, Quaternion.identity);
                    Destroy(hit, 1F);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            animator.ResetTrigger("Attack");
        }
    }
}