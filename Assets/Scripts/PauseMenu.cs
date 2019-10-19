using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public bool pauseActive = false;

    void Start()
    {
        //pauseCanvas.enabled = false;
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = !pauseActive;
            if (pauseActive == true)
            {
                Time.timeScale = 0;
                //pauseCanvas.enabled = true;
                pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                //pauseCanvas.enabled = false;
                pauseCanvas.gameObject.SetActive(false);
            }
        }
    }
}
