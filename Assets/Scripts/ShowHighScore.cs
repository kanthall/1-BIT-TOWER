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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteKey("Highscore");
            Debug.Log("Score reset");
        }
    }
}
