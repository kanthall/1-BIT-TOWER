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

    [Header("Units Canvases")]
    [SerializeField]Canvas wizardStats;
    [SerializeField]Canvas knightStats;
    [SerializeField]Canvas berzerkStats;
    [SerializeField]Canvas mageStats;

    Canvas currentUnitCanvas;

    [Header("Selected Unit Sound")]
    [SerializeField] AudioClip selectedUnitSound;
    [SerializeField] [Range(0, 1)] float selectedUnitSoundVolume = 1f;
    
    [Header("Particles")]
    public GameObject instantiateParticle;

    [Header("Various")]
    [SerializeField] public int currentUnitPrice = -1;
    private Money money;
    private UnitType currentUnitType = UnitType.WIZARD;
    
    private List<Units> unitsButtons = new List<Units>();
    AudioSource audioSource;
    public UnitType CurrentUnitType {  get { return currentUnitType; } }

    public bool wizard;
    public bool mage;
    public bool berzerker;
    public bool knight;
    
    private void Start()
    {
        money = FindObjectOfType<Money>();
        currentUnitType = UnitType.NONE;

        wizardStats.gameObject.SetActive(false);
        knightStats.gameObject.SetActive(false);
        berzerkStats.gameObject.SetActive(false);
        mageStats.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        ShowCanvas();
    }

    public void InstantiateUnit(Transform unitPlace)
    {
       GameObject unitPrefab = null;

        switch (currentUnitType)
        {
            case UnitType.WIZARD:
                {
                    unitPrefab = wizardPrefab;
                    wizard = true;
                    berzerker = false;
                    knight = false;
                    mage = false;
                }   break;

            case UnitType.KNIGHT:
                {
                    unitPrefab = knightPrefab;
                    knight = true;
                    wizard = false;
                    berzerker = false;
                    mage = false;
                }   break;

            case UnitType.BERZERKER:
                {
                    unitPrefab = berzerkerPrefab;
                    berzerker = true;
                    wizard = false;
                    knight = false;
                    mage = false;
                }   break;

            case UnitType.MAGE:
                {
                    unitPrefab = magePrefab;
                    mage = true;
                    wizard = false;
                    berzerker = false;
                    knight = false;
                }   break;
        }

        if (money.Gold <= 0)
        {
            Debug.Log("NIE MAMY KASY");
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

            if ((money.Gold - currentUnitPrice) < 0)
            {
                FindObjectOfType<PlacingUnits>().StartCoroutine("NoMoreMoney");
                return;
            }
            else
            { 
            money.Gold = money.Gold - currentUnitPrice;
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
                {
                    btn.GetSpriteRenderer.color = new Color32(0, 255, 11, 255);
                    audioSource.PlayOneShot(selectedUnitSound, selectedUnitSoundVolume);
                    UnitsShortcuts();
                }
                else
                {
                    btn.GetSpriteRenderer.color = Color.white;
                }
            }
        }
    }

    private void UnitsShortcuts()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectUnitButton(UnitType.BERZERKER, 2);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectUnitButton(UnitType.KNIGHT, 5);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectUnitButton(UnitType.WIZARD, 20);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectUnitButton(UnitType.MAGE, 25);
            }
    }

    private void ShowCanvas()
    {
        if (berzerker)
        {
            berzerkStats.gameObject.SetActive(true);
            wizardStats.gameObject.SetActive(false);
            knightStats.gameObject.SetActive(false);
            mageStats.gameObject.SetActive(false);
        }

        if (knight)
        {
            knightStats.gameObject.SetActive(true);
            wizardStats.gameObject.SetActive(false);
            berzerkStats.gameObject.SetActive(false);
            mageStats.gameObject.SetActive(false);
        }

        if (wizard)
        {
           wizardStats.gameObject.SetActive(true);
           knightStats.gameObject.SetActive(false);
           berzerkStats.gameObject.SetActive(false);
           mageStats.gameObject.SetActive(false);
        }

        if (mage)
        {
            mageStats.gameObject.SetActive(true);
            wizardStats.gameObject.SetActive(false);
            knightStats.gameObject.SetActive(false);
            berzerkStats.gameObject.SetActive(false);
        } 
    }
}
 


        