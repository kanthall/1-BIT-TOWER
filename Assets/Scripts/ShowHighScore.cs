using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] public Text highscore;
    private int temp;

    private SteamAchievements achievements;

    private void Start()
    {
        temp = PlayerPrefs.GetInt("Highscore", 0);
        highscore.text = temp.ToString();

        
    }
}
