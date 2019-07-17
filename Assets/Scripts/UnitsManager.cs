using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { NONE, WIZARD, KNIGHT, BERZERKER, MAGE }

public class UnitsManager : MonoBehaviour
{
    [Header("Units Prefabs")]
    public GameObject wizardPrefab;
    public GameObject knightPrefab;
    public GameObject berzerkerPrefab;
    public GameObject magePrefab;

    [Header("Particles")]
    public GameObject instantiateParticle;

    private GameManagerBehaviour gameManagerBehaviour = null;
    private UnitType currentUnitType = UnitType.WIZARD;
    [SerializeField] public int currentUnitPrice = -1;
    private List<Units> unitsButtons = new List<Units>();

    public UnitType CurrentUnitType {  get { return currentUnitType; } }

    private void Start()
    {
        gameManagerBehaviour = FindObjectOfType<GameManagerBehaviour>();
        currentUnitType = UnitType.NONE;
    }

    public void InstantiateUnit(Transform unitPlace)
    {
        GameObject unitPrefab = null;

        switch (currentUnitType)
        {
            case UnitType.WIZARD:
                unitPrefab = wizardPrefab;
                break;
            case UnitType.KNIGHT:
                unitPrefab = knightPrefab;
                break;
            case UnitType.BERZERKER:
                unitPrefab = berzerkerPrefab;
                break;
            case UnitType.MAGE:
                unitPrefab = magePrefab;
                break;
        }

        if (gameManagerBehaviour.Gold <= 0)
        {
            return;
        }
        else
        {
            Transform unitTransform = Instantiate(unitPrefab, unitPlace).transform;
            unitTransform.localPosition = new Vector3(0, 0, 0);
            unitTransform.localRotation = new Quaternion(0, 0, 0, 0);

            Transform particle = Instantiate(instantiateParticle, unitPlace).transform;
            particle.localPosition = new Vector3(0.075f, -0.085f, 0);
            particle.localRotation = new Quaternion(0, 0, 0, 0);

            Destroy(particle.gameObject, 1.0f);

            //zablokowane wyświetlanie wartości liczby
            if ((gameManagerBehaviour.Gold - currentUnitPrice) <= 0)
            {
                return;
            }
            else
            { 
            gameManagerBehaviour.Gold = gameManagerBehaviour.Gold - currentUnitPrice;
            }
    }
    }

    public void AddUnitButton(Units unitBtn)
    {
        unitsButtons.Add(unitBtn);
    }

    public void SelectUnitButton(UnitType unitType, int price)
    {
        currentUnitPrice = price;
        currentUnitType = unitType;

        foreach (var btn in unitsButtons)
        {
            if (btn != null)
            {
                if (btn.GetUnitType == unitType)
                    btn.GetSpriteRenderer.color = new Color32(230, 72, 46, 255);
                else
                    btn.GetSpriteRenderer.color = Color.white;
            }
        }
    }
}