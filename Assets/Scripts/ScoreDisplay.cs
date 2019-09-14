﻿
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] public Text scoreText;
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<ScoreDisplay>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        scoreText.text = "SCORE" + " - " + GetScore().ToString(); 
        SavePoints();
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void SavePoints()
    {
        if (GetScore() > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", GetScore());
            PlayerPrefs.Save();
        }
    }
}