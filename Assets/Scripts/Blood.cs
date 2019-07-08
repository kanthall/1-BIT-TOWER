﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] int blood;
    [SerializeField] GameObject bloodFading;

    private void OnMouseUp()
    {
        var next = FindObjectOfType<GameManagerBehaviour>();

        next.Gold += blood;
        Destroy(gameObject);

        GameObject deathVFXObject = Instantiate(bloodFading, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
