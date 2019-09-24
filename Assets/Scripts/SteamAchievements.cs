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
    CrownsStealing health;

    /*
     void Awake()
    {
        script = this;
        if(!SteamManager.Initialized)
        {
            gameObject.SetActive(false);
        }
    }
    */
    private void Start()
    {
        Debug.Log("ready");

        waveManager = FindObjectOfType<WaveManager>();
        waveValue = waveManager.GetWave();

        health = GetComponent<CrownsStealing>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("testowo");
            UnlockSteamAchievement("1WildBerzerker");
        }


        if(Input.GetKeyDown(KeyCode.C))
        {
            DEBUG_LockSteamAchievement("1WildBerzerker");
        }

        if(waveValue >= 2 && health.crowns.Count <= 0)
        {
            UnlockSteamAchievement(" ten z 10 falami ");
            Debug.Log("dałeś radę");
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
