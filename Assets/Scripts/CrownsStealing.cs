using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrownsStealing : MonoBehaviour
{
    [Header("Crowns display")]
    [SerializeField] public int health;
    [SerializeField] public Text healthValue;

    [Header("Elements in the list")]
    [SerializeField] public List<GameObject> crowns = new List<GameObject>();
    
    private CameraShake cameraShake;
    private LevelManager levelManager;

    [SerializeField] Canvas crownsLost;

    [SerializeField] float timer = 3; 
    
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        health = crowns.Count;
        healthValue.GetComponent<Text>().text = "" + health;
        levelManager = FindObjectOfType<LevelManager>();

        crownsLost.enabled = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            crownsLost.enabled = true;
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                levelManager.LoadGameOver();
            }
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
    }
}




