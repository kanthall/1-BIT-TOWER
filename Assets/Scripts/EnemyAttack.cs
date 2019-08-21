﻿using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float firstAttackTime;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] [Range(0, 1)] float attackSoundVolume = 0.50f;
    [SerializeField] public int attackPower;
    [SerializeField] GameObject attackParticle;

    private EnemyMovement enemyMovement = null;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            enemyMovement.isMoving = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            firstAttackTime -= Time.deltaTime;

            if (firstAttackTime <= 0f)
            {
                AudioSource.PlayClipAtPoint(attackSound, new Vector3(0, 0, 0), attackSoundVolume);
                firstAttackTime = timeBetweenAttacks;

                animator.SetTrigger("Attack");

                if (collision.transform.parent.GetComponent<UnitHealth>())
                {
                    UnitHealth unitHealth = collision.transform.parent.GetComponent<UnitHealth>();
                    unitHealth.TakeDamage(attackPower);
                    var particle = Instantiate(attackParticle, unitHealth.transform.position, Quaternion.identity);
                    Destroy(particle, 0.3f);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            enemyMovement.isMoving = true;
        }
    }
}