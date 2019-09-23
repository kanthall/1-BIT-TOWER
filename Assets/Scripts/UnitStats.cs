using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour
{
    [SerializeField] public Text unitName;
    [SerializeField] public Text unitHP;

    void Start()
    {
        unitName.GetComponent<Text>().text = GetComponent<UnitHealth>().unitName;

        unitHP.GetComponent<Text>().text = GetComponent<UnitHealth>().startHealth + " HP";
    }
}
