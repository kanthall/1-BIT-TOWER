using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_wizard_projectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 1;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Script_enemy_health>();
        var attacker = otherCollider.GetComponent<Script_enemy_move>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }  
    }
}
