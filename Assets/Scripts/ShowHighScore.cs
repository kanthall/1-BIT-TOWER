using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] public Text highscore;
    private int temp;
    private int saved;

    private void Start()
    {
        temp = PlayerPrefs.GetInt("Highscore", 999);
        highscore.text = temp.ToString();
        
        //PlayerPrefs.DeleteKey("Highscore");
    }
}
