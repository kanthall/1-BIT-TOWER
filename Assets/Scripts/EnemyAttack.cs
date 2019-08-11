using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float firstAttackTime;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] AudioClip attack;
    [SerializeField] bool enemyMove;

    private void Start()
    {
        //enemyMove = gameObject.GetComponent<EnemyMovement>().isMoving;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            gameObject.GetComponent<EnemyMovement>().isMoving = false;

            firstAttackTime -= Time.deltaTime;

            if (firstAttackTime <= 0f)
            {
                StartCoroutine("WaitTwoSeconds");
                //animator.SetTrigger("Attack");
                Debug.Log("Attacked");
                firstAttackTime = timeBetweenAttacks;
            }
            else
            {
                animator.ResetTrigger("Shoot");
            }
        }
    }

    IEnumerable WaitTwoSeconds()
    {
        yield return new WaitForSeconds(0);
        Debug.Log("waited");
        Attack();
    }

    void Attack()
    {
        AudioSource.PlayClipAtPoint(attack, new Vector3(0, 0, 0));
    }
}
