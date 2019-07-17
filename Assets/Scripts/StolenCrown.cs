using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenCrown : MonoBehaviour
{
    [SerializeField] GameObject stolenCrown;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("done");
        stolenCrown.GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
