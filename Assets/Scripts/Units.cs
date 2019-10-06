using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] private UnitType unitType;
    [SerializeField] private int price = 50;
    //[SerializeField] private Canvas statsCanvas;

    private UnitsManager unitsManager = null;
    private SpriteRenderer spriteRenderer;

    public int Price { get { return price; } }
    public UnitType GetUnitType { get { return unitType; } }
    public SpriteRenderer GetSpriteRenderer { get { return spriteRenderer; } }

    private void Start()
    {
        unitsManager = FindObjectOfType<UnitsManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        unitsManager.AddUnitButton(this);
    }

    private void OnMouseUp()
    {
        unitsManager.SelectUnitButton(unitType, price);
    }
}