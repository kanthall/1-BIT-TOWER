using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrownsTest : MonoBehaviour
{
    [Header("Crowns display")]
    [SerializeField] int health;
    [SerializeField] public Text healthValue;

    [Header("Elements in the list")]
    [SerializeField] List<GameObject> crowns = new List<GameObject>();
    
    private CameraShake cameraShake;
 
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        health = crowns.Count;
        healthValue.GetComponent<Text>().text = "" + health;
    }

    void Update()
    {
        if (health <= 0)
        {
            FindObjectOfType<LevelManager>().LoadGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraShake.Shake();

        health -= 1;
        healthValue.text = health.ToString();

        if (crowns.Count != 0)
        {
            GameObject selectedCrown = crowns[crowns.Count - 1];
            selectedCrown.SetActive(false);
            crowns.Remove(selectedCrown);
        }
        else
        {
            Debug.Log("Empty list! No more crowns!");
        }
    }
}




