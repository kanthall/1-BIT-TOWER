using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("log 100");
        Destroy(collision.gameObject);
    }
}
