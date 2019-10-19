using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.SceneManagement;

public class SteamAchievements : MonoBehaviour
{
    public static SteamAchievements script;
    private bool unlockTest = false;

    void Awake()
    {
        if (!SteamManager.Initialized)
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

    void Update()
    {
        //Deleting();

       /* if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteKey("Highscore");
            Debug.Log("Score reset");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.DeleteKey("EnemiesKilled");
            Debug.Log("Enemies killed reset");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteKey("HeroesBought");
            Debug.Log("Heroes bought reset");
        }
        */
    }

    public void UnlockSteamAchievement(string ID)
    {
        TestSteamAchievement(ID);
        if (!unlockTest)
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

    public void Unlocking(int wave, int health)
    {
        if (wave == 6 && health >= 1)
        {
            UnlockSteamAchievement("6Training");
        }

        if (wave == 11 && health >= 1)
        {
            UnlockSteamAchievement("7PreparedHero");
        }

        if (wave == 16 && health >= 1)
        {
            UnlockSteamAchievement("8TrueDefender");
        }
    }

    public void Unlocking(int enemiesKilled)
    {
        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 11)
        {
            UnlockSteamAchievement("1WildBerzerker");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 101)
        {
            UnlockSteamAchievement("2NobleKnight");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 501)
        {
            UnlockSteamAchievement("3MightyWizard");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 1001)
        {
            UnlockSteamAchievement("4PowerfullMage");
        }
    }

    public void Unlocking2(int heroesBought)
    {
        if (PlayerPrefs.GetInt("HeroesBought", 0) == 501)
        {
            UnlockSteamAchievement("5AnArmy");
        }
    }

    public void Unlocking3(int highScore)
    {
        if (PlayerPrefs.GetInt("Highscore", 0) > 1000)
        {
            UnlockSteamAchievement("9TheLeader");
        }
    }

    private void Deleting()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DEBUG_LockSteamAchievement("1WildBerzerker");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            DEBUG_LockSteamAchievement("2NobleKnight");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DEBUG_LockSteamAchievement("3MightyWizard");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            DEBUG_LockSteamAchievement("4PowerfullMage");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            DEBUG_LockSteamAchievement("5AnArmy");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            DEBUG_LockSteamAchievement("6Training");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            DEBUG_LockSteamAchievement("7PreparedHero");
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            DEBUG_LockSteamAchievement("8TrueDefender");
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            DEBUG_LockSteamAchievement("9TheLeader");
        }
    }

    public void SaveKills()
    {
        return;
    }

    public void SaveHeroesTrained()
    {
        return;
    }
}