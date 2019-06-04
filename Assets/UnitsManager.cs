using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    [SerializeField] GameObject unitType;


    void OnMouseUp()
    {
        GameObject type = FindObjectOfType<PlacingUnits>().unitPrefab;
        type = unitType;
        Debug.Log(unitType.name);
    }
}
