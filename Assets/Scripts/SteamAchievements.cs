using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamAchievements : MonoBehaviour
{
    public static SteamAchievements script;
    private bool unlockTest = false;
    private WaveManager waveManager;
    private int waveValue;
    private int scoreToCompare = 10;
    CrownsStealing health;
    
     void Awake()
    {
        if(!SteamManager.Initialized)
        {
            gameObject.SetActive(false);
        }

        if (script != null)
        {
            Destroy(gameObject);
        }
        script = this;

        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        waveValue = waveManager.GetWave();

        health = GetComponent<CrownsStealing>();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            UnlockSteamAchievement("1WildBerzerker");
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            DEBUG_LockSteamAchievement("1WildBerzerker");
        }

        if(waveValue == 2 && health.crowns.Count >= 0)
        {
            UnlockSteamAchievement("6Training");
        }

        if(PlayerPrefs.GetInt("Highscore", 0) > scoreToCompare) 
        {
            UnlockSteamAchievement("9TheLeader");
        }
    }
    
    public void UnlockSteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        if(!unlockTest)
        {
            SteamUserStats.SetAchievement(ID);
            SteamUserStats.StoreStats();
        }
    }

    void TestSteamAchievement(string ID)
    {
        SteamUserStats.GetAchievement(ID, out unlockTest);
    }

    public void DEBUG_LockSteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        if (unlockTest)
        {
            SteamUserStats.ClearAchievement(ID);
        }
    }
}
