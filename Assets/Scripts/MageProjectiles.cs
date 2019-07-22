﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageProjectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 2;
    float timeToDestroyProjectiles = 1f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
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
        }
    }
}
