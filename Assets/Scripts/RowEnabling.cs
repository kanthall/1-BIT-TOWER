using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowEnabling : MonoBehaviour
{
    [SerializeField] List<GameObject> row1 = new List<GameObject>();
    [SerializeField] List<GameObject> row2 = new List<GameObject>();
    [SerializeField] List<GameObject> row3 = new List<GameObject>();
    [SerializeField] List<GameObject> row4 = new List<GameObject>();
    [SerializeField] List<GameObject> row5 = new List<GameObject>();
    [SerializeField] List<GameObject> row6 = new List<GameObject>();

    List<GameObject> rowlist = new List<GameObject>();

    void Start()
    {
        foreach (GameObject box in row1)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row2)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row3)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row4)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row5)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row6)
        {
            box.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            foreach (GameObject box in row1)
            {
                box.SetActive(false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            foreach (GameObject box in row1)
            {
                box.SetActive(true);
            }
        }
    }
}

