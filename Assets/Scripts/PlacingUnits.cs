using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingUnits : MonoBehaviour
{

    [SerializeField] private GameObject unitPrefab;
    private GameObject unit;
    

    private bool canPlaceUnit()
    {
        return unit == null;
    }

    
    void OnMouseUp()
    {
       
        if (canPlaceUnit())
        {
            
            unit = (GameObject)
            Instantiate(unitPrefab , transform.position, Quaternion.identity);

            


            // TODO: Deduct gold
        }
        
    }

    void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32(245, 50, 50, 255);
    }

    void OnMouseExit()
    {
        if (canPlaceUnit())
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color32(245, 50, 50, 255);
        }
    }
}
