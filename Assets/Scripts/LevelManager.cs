using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 4f;

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {

        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Scene_game_over");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Scene_game");
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

}
