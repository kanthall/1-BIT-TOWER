using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    

    [SerializeField] float delayInSeconds = 20f;

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("3Scene_game_over");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("2Scene_game");
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
