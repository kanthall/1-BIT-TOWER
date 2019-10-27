using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float delayInSeconds = 3f;
    public Canvas pauseCanvas;
    private YesNo accept;
    private int interval = 3;

    Tutorial tutek;
    PauseMenu pause;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        accept = FindObjectOfType<YesNo>();
        tutek = FindObjectOfType<Tutorial>();
        pause = FindObjectOfType<PauseMenu>();
    }

    private void Update()
    {
        //Restart();
        if (Time.frameCount % interval == 0)
        {
            Escape();
        }
    }

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
        Destroy(MusicPlayer.Instance.gameObject);
        SceneManager.LoadScene("2Scene_game"); 
    }

    public void LoadMenu()
    {
        accept.OpenYesNo();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {      
        Application.Quit();
    }

    public void LoadBestiary()
    {
        SceneManager.LoadScene("5Scene_bestiary");
        Time.timeScale = 1;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("4Scene_credits");
        Time.timeScale = 1;
    }
    
    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadGame();
            Time.timeScale = 1;
        }
    }

    private void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "1Scene_menu")
            {
                Application.Quit();
            }
        }
    } 

    public void ScreenChange()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
        tutek.TutorialOff();
        pause.pauseOff();
    }
}