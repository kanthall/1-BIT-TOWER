using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 0.5f;    

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        
        transform.Translate(Vector3.left * Time.deltaTime * enemyMoveSpeed);
    }
}
