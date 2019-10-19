using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YesNo : MonoBehaviour
{
    [SerializeField] Canvas YesNoCanvas;
    LevelManager manager;

    void Start()
    {
        YesNoCanvas.enabled = false;
        manager = FindObjectOfType<LevelManager>();
    }

    public void OpenYesNo()
    {
        YesNoCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void Yes()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void No()
    {
        YesNoCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
