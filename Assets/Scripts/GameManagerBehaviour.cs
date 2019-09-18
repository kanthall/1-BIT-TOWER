using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] public Text bloodLabel;
    [SerializeField] int money;

    private void Start()
    {
        Gold = money;
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
