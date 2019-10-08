using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public bool pauseActive = false;

    void Start()
    {
        pauseCanvas.enabled = false;
    }

    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = !pauseActive;
            if (pauseActive == true)
            {
                Time.timeScale = 0;
                pauseCanvas.enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseCanvas.enabled = false;
            }
        }
    }
}
