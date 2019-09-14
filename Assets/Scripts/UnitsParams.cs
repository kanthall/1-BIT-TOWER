using UnityEngine;

[CreateAssetMenu(menuName = "1BIT/UnitsParams")]
public class UnitsParams : ScriptableObject
{
    public GameObject prefab = null;
    public float unitCost = 10;
    public float unitLife = 10;
    public string key = "key";
}
