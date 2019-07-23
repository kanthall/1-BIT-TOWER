using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenCrown : MonoBehaviour
{
    [SerializeField] GameObject stolenCrown;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CrownTrigger"))
        {
            stolenCrown.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    
}
