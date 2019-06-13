using UnityEngine;

public class PlacingUnits : MonoBehaviour
{
    private UnitsManager unitsManager = null;
    private GameManagerBehaviour gameManagerBehaviour = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isEmpty = true;

    [Header("Sound")]
    [SerializeField] AudioClip placingSound;
    [SerializeField] [Range(0, 1)] float placingSoundVolume = 1f;

    private void Start()
    {
        unitsManager = FindObjectOfType<UnitsManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerBehaviour = FindObjectOfType<GameManagerBehaviour>();
    }

    private void OnMouseUp()
    {
        if (!isEmpty || unitsManager.CurrentUnitType == UnitType.NONE)
        {
            return;
        }

        //zablokowane ustawianie jednostki wartości liczby
        if (gameManagerBehaviour.Gold - unitsManager.currentUnitPrice <= 0)
        {
            //zmiana koloru blood text
            gameManagerBehaviour.bloodLabel.color = Color.red;
            return;
        }

        unitsManager.InstantiateUnit(gameObject.transform);
        spriteRenderer.enabled = false;
        isEmpty = false;
        AudioSource.PlayClipAtPoint(placingSound, Camera.main.transform.position, placingSoundVolume);
    }

    private void OnMouseOver()
    {
        if (!isEmpty)
            return;

        spriteRenderer.material.color = new Color32(255, 177, 177, 255);
    }

    private void OnMouseExit()
    {
        if (isEmpty == false) //(!isEmpty)
        {
            return;
        }
        else
        { 
        spriteRenderer.material.color = Color.white;
        }
    }
}