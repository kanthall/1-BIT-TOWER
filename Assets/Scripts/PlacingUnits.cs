using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingUnits : MonoBehaviour
{

    [SerializeField] public GameObject unitPrefab;
    [SerializeField] GameObject placingParticle;
    private GameObject unit;
    [SerializeField] GameObject particlePlace;

    [SerializeField] bool unitPlacing = false;

    private void Start()
    {
        
    }


    private bool canPlaceUnit()
    {
        return unit == null;
    }

    
    void OnMouseUp()
    {
        var next = FindObjectOfType<GameManagerBehaviour>();

        if (canPlaceUnit() && unitPlacing == false)
        {
            if (next.Gold == 0)
            {
                Debug.Log("koniec kasy");
                next.Gold = 0;
                unitPlacing = true;
                return;
            }
            else
            {
                unit = (GameObject) Instantiate(unitPrefab, transform.position, Quaternion.identity);
                Instantiate(placingParticle, particlePlace.transform.position, Quaternion.identity);
                Destroy(placingParticle, 1f);
                next.Gold = next.Gold - 50;
            }
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
