using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] int blood;

    private void OnMouseUp()
    {
        var next = FindObjectOfType<GameManagerBehaviour>();

        next.Gold += blood;
        Destroy(gameObject);
    }
}
