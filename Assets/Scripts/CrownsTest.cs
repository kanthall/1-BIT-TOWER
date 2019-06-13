using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrownsTest : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject[] crown;
    float delayInSeconds = 2;

    void Start()
    {
        crown = GameObject.FindGameObjectsWithTag("Crown");
        health = crown.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("KONIEC");

            StartCoroutine(WaitAndLoad());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= 1;
        
    }

    IEnumerator WaitAndLoad()
    {

        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Scene_game_over");
    }
}




