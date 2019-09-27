using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] public Text bloodLabel;
    [SerializeField] int money;
    private int gold;

    private void Start()
    {
        Gold = money;
    }

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
