using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlacingUnits : MonoBehaviour
{
    private UnitsManager unitsManager;
    private Money money;
    private SpriteRenderer spriteRenderer;
    private bool isEmpty = true;

    [Header("Placing Sound")]
    [SerializeField] AudioClip placingSound;
    [SerializeField] [Range(0, 1)] float placingSoundVolume = 1f;

    [Header("No Unit Selected Sound")]
    [SerializeField] AudioClip noUnitSelectedSound;
    [SerializeField] [Range(0, 1)] float noUnitSelectedSoundVolume = 1f;
    
    [Header("No More Money Sound")]
    [SerializeField] AudioClip noMoreMoneySound;
    [SerializeField] [Range(0, 1)] float noMoreMoneySoundVolume = 1f;

    private NoUnitSelected noUnitSelected;
    private NoMoreMoney noMoreMoney;
    private BoxCollider2D box2d;
    private AudioSource audioSource;
    private PauseMenu pauseMenu;
    private Tutorial tutorialMenu;

    private SteamAchievements achievements;
    
    private void Start()
    {
        unitsManager = FindObjectOfType<UnitsManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        money = FindObjectOfType<Money>();

        spriteRenderer.material.color = Color.gray;

        noUnitSelected = FindObjectOfType<NoUnitSelected>();
        noMoreMoney = FindObjectOfType<NoMoreMoney>();

        box2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        pauseMenu = FindObjectOfType<PauseMenu>();
        tutorialMenu = FindObjectOfType<Tutorial>();

        achievements = FindObjectOfType<SteamAchievements>();
    }

    private void OnMouseUp()
    {
        if (pauseMenu.pauseActive == true || tutorialMenu.tutorialEnabled == true)
        {
            return;
        }

        if (!isEmpty || unitsManager.CurrentUnitType == UnitType.NONE)
        {
            StartCoroutine(NoUnitSelected());
            return;
        }

        if (money.Gold - unitsManager.currentUnitPrice < 0)
        {
            StartCoroutine("NoMoreMoney");
            return;
        }

        unitsManager.InstantiateUnit(gameObject.transform);
        spriteRenderer.enabled = false;
        
        isEmpty = false;
        audioSource.PlayOneShot(placingSound, placingSoundVolume);

        PlayerPrefs.SetInt("HeroesBought", PlayerPrefs.GetInt("HeroesBought") + 1);
        achievements.Unlocking2(PlayerPrefs.GetInt("HeroesBought", 0));
    }

    private void OnMouseOver()
    {
        if (!isEmpty)
            return;

        spriteRenderer.material.color = new Color32(230, 72, 46, 255);
    }

    private void OnMouseExit()
    {
        if (isEmpty)
        {
            spriteRenderer.material.color = Color.gray;
        }
    }

    IEnumerator NoUnitSelected()
    {
        AudioSource.PlayClipAtPoint(noUnitSelectedSound, Camera.main.transform.position, noUnitSelectedSoundVolume);
        noUnitSelected.noUnitSelectedText1.enabled = true;
        noUnitSelected.noUnitSelectedText2.enabled = true;
        noUnitSelected.noUnitSelectedImage.enabled = true;
        yield return new WaitForSeconds(1);
        noUnitSelected.noUnitSelectedText1.enabled = false;
        noUnitSelected.noUnitSelectedText2.enabled = false;
        noUnitSelected.noUnitSelectedImage.enabled = false;
    }
    
    IEnumerator NoMoreMoney()
    {
        AudioSource.PlayClipAtPoint(noMoreMoneySound, Camera.main.transform.position, noMoreMoneySoundVolume);
        noMoreMoney.noMoneyText1.enabled = true;
        noMoreMoney.noMoneyText2.enabled = true;
        noMoreMoney.noMoneyTextImage.enabled = true;
        yield return new WaitForSeconds(1);
        noMoreMoney.noMoneyText1.enabled = false;
        noMoreMoney.noMoneyText2.enabled = false;
        noMoreMoney.noMoneyTextImage.enabled = false;
    }
}