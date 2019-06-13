using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] public Text bloodLabel;

    private void Start()
    {
        Gold = 50;
    }

    private int gold;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            bloodLabel.GetComponent<Text>().text = "" + gold;
        }
    }
}
