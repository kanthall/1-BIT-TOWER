using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenCrowns : MonoBehaviour
{
    [SerializeField] GameObject stolenCrown;

    [Header("Stealing sound")]
    [SerializeField] AudioClip stealSound;
    [SerializeField] [Range(0, 1)] float stealSoundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CrownTrigger"))
        {
            stolenCrown.GetComponent<SpriteRenderer>().enabled = true;
            AudioSource.PlayClipAtPoint(stealSound, Camera.main.transform.position, stealSoundVolume);
        }
    }
    
}
