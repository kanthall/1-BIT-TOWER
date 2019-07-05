using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrownsTest : MonoBehaviour
{
    [SerializeField] int health;

    [SerializeField] List<GameObject> crowns = new List<GameObject>();

    float delayInSeconds = 10;

    void Start()
    {
        health = crowns.Count;
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
        crowns.RemoveAt(crowns.Count - 1);
        //usuwanie za każdą kolizję do dodania
        Destroy(GameObject.FindWithTag("Crown"));
    }

    IEnumerator WaitAndLoad()
    {

        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Scene_game_over");
    }
}




