using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieuzywanyFlowersSeeder : MonoBehaviour
{
    // the range of X cordinate
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y cordinate
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    [Header("Game elements to spawn")]
    [SerializeField] private int numberOfObjects;
    [SerializeField] private GameObject[] theGoodies;


    void Start()
    {
        for (int i = 0; i <= numberOfObjects; i++)
        {
            GameObject goodsPrefab = theGoodies[UnityEngine.Random.Range(0, theGoodies.Length)];

            Vector2 boxSize = goodsPrefab.GetComponent<BoxCollider2D>().size;
            Vector2 grassPos = new Vector2(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax));

            int attempts = 0;
            while (Physics2D.OverlapBox(grassPos, boxSize, 0f))
            {
                grassPos = new Vector2(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax));
                attempts++;
                if (attempts > 10)
                {
                    Debug.Log("Can't spawn in this place");
                    return;
                }
            }
            //Instantiate(goodsPrefab, grassPos, Quaternion.identity);
            var newObject = Instantiate(goodsPrefab, grassPos, Quaternion.identity);
            newObject.transform.parent = gameObject.transform;
            Debug.Log("Item spawn");
        }
    }
}