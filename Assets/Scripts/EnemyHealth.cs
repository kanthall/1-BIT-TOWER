using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemie Stats")]
    [SerializeField] int enemyHealth = 0;
    [SerializeField] int scoreValue = 150;

    [Header("Visual & sound")]
    [SerializeField] GameObject deathParticle;
    [SerializeField] AudioClip hitSound;

    //on hit - deal damage
    public void DealDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            showDeathParticle();
            //on health 0 - destroy game object
            Destroy(gameObject);
        }
    }

    private void showDeathParticle()
    {
        if (!deathParticle) { return; }
        GameObject deathVFXObject = Instantiate(deathParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, 0));
        Destroy(deathVFXObject, 0.5f);
    }
}