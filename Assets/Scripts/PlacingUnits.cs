using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlacingUnits : MonoBehaviour
{
    private UnitsManager unitsManager = null;
    private GameManagerBehaviour gameManagerBehaviour = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isEmpty = true;

    [Header("Placing Sound")]
    [SerializeField] AudioClip placingSound;
    [SerializeField] [Range(0, 1)] float placingSoundVolume = 1f;

    [Header("No Unit Selected Sound")]
    [SerializeField] AudioClip noUnitSelectedSound;
    [SerializeField] [Range(0, 1)] float noUnitSelectedSoundVolume = 1f;

    private NoUnitSelected noUnitSelected;

    private void Start()
    {
        unitsManager = FindObjectOfType<UnitsManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerBehaviour = FindObjectOfType<GameManagerBehaviour>();

        spriteRenderer.material.color = Color.gray;

        noUnitSelected = FindObjectOfType<NoUnitSelected>();
    }

    private void OnMouseUp()
    {
        if (!isEmpty || unitsManager.CurrentUnitType == UnitType.NONE)
        {
            StartCoroutine(NoUnitSelected());
            return;
        }

        //zablokowane ustawianie jednostki wartości liczby
        if (gameManagerBehaviour.Gold - unitsManager.currentUnitPrice <= 0)
        {
            //zmiana koloru blood text
            gameManagerBehaviour.bloodLabel.color = Color.red;
            return;
        }
        else
        {
            //zmiana koloru blood text
            gameManagerBehaviour.bloodLabel.color = Color.white;
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

        spriteRenderer.material.color = new Color32(230, 72, 46, 255);
    }

    private void OnMouseExit()
    {
        if (isEmpty == false) //(!isEmpty)
        {
            return;
        }
        else
        { 
        spriteRenderer.material.color = Color.gray;
        }
    }

    IEnumerator NoUnitSelected()
    {
        AudioSource.PlayClipAtPoint(noUnitSelectedSound, Camera.main.transform.position, noUnitSelectedSoundVolume);
        noUnitSelected.noUnitSelectedText.enabled = true;
        noUnitSelected.noUnitSelectedImage.enabled = true;
        yield return new WaitForSeconds(1);
        noUnitSelected.noUnitSelectedText.enabled = false;
        noUnitSelected.noUnitSelectedImage.enabled = false;
    }
}