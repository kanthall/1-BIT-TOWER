using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrownsTest : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] public Text healthValue;
    [SerializeField] List<GameObject> crowns = new List<GameObject>();

    private CameraShake cameraShake;

    float delayInSeconds = 2;

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
            StartCoroutine(WaitAndLoad());
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

    IEnumerator WaitAndLoad()
    {

        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Scene_game_over");
    }
}




