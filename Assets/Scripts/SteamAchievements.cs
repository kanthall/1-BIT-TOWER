using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.SceneManagement;

public class SteamAchievements : MonoBehaviour
{
    public static SteamAchievements script;
    private bool unlockTest = false;

    private int scoreToCompare = 10;
    [SerializeField] int crowns;
    [SerializeField] int waveValue;
    
     void Awake()
    {
        if(!SteamManager.Initialized)
        {
            gameObject.SetActive(false);
            Debug.Log("nie działam");
        }
        else
        {
            Debug.Log("działam");
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
        Unlocking();
        Deleting();


        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("Highscore");
            Debug.Log("Score reset");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerPrefs.DeleteKey("EnemiesKilled");
            Debug.Log("Enemies killed reset");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.DeleteKey("HeroesBought");
            Debug.Log("Heroes bought reset");
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

    private void Unlocking()
    {
        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 11)
        {
            UnlockSteamAchievement("1WildBerzerker");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 101)
        {
            UnlockSteamAchievement("2NobleKnight");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 1001)
        {
            UnlockSteamAchievement("3MightyWizard");
        }

        if (PlayerPrefs.GetInt("EnemiesKilled", 0) == 10001)
        {
            UnlockSteamAchievement("4PowerfullMage");
        }

        if (PlayerPrefs.GetInt("HeroesBought", 0) == 501)
        {
            UnlockSteamAchievement("5AnArmy");
        }

        if (waveValue == 2 && crowns >= 1)
        {
            Debug.Log("Zdobyte 6Training");
            UnlockSteamAchievement("6Training");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            UnlockSteamAchievement("7PreparedHero");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            UnlockSteamAchievement("8TrueDefender");
        }

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
