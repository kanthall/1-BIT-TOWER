using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    [SerializeField] public Text unitName;
    [SerializeField] public Text unitHP;
    [SerializeField] public Text unitDMG;

    void Start()
    {
        unitName.GetComponent<Text>().text = GetComponent<EnemyHealth>().unitName;

        unitHP.GetComponent<Text>().text = GetComponent<EnemyHealth>().startHealth + " HP";

        unitDMG.GetComponent<Text>().text = GetComponent<EnemyAttack>().attackPower + " DMG";
    }
}
