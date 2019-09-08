using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float delayInSeconds = 3f;
    
    public void LoadGameOver()        
    {
        animator.SetTrigger("FadeOut");
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

    public void LoadBestiary()
    {
        SceneManager.LoadScene("5Scene_bestiary");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("4Scene_credits");
    }
    
    private void Update()
    {
        Restart();
    }
    
    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadGame();
        }
        else
        {
            return;
        }
    }
}
