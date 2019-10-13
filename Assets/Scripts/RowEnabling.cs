using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowEnabling : MonoBehaviour
{
    [SerializeField] List<GameObject> row1 = new List<GameObject>();
    [SerializeField] List<GameObject> row2 = new List<GameObject>();
    [SerializeField] List<GameObject> row3 = new List<GameObject>();
    [SerializeField] List<GameObject> row4 = new List<GameObject>();
    [SerializeField] List<GameObject> row5 = new List<GameObject>();
    [SerializeField] List<GameObject> row6 = new List<GameObject>();

    private Money money = null;
    private PlacingUnits placingUnits;
    private int rowPrice = 10;
    [SerializeField] int rowsToBuy = 6;
    [SerializeField] GameObject rowsButton;

    [Header("Sound")] 
    [SerializeField] private AudioClip buyingSound;
    [SerializeField] [Range(0, 1)] float buyingSoundVolume = 0.75f;
    private AudioSource audio;
    [SerializeField] GameObject child;

    PlacingUnits noMoney;
    
    void Start()
    {
        RowsDisabling();
        money = FindObjectOfType<Money>();
        placingUnits = GetComponent<PlacingUnits>();
        audio = GetComponent<AudioSource>();
        noMoney = FindObjectOfType<PlacingUnits>();
    }

    public void BuyRow()
    {
        if (rowsToBuy > 0)
        {
            if (money.Gold > rowPrice)
            {
                if (rowsToBuy == 6)
                {
                    if (money.Gold <= 0)
                    {
                        noMoney.StartCoroutine("NoMoreMoney");
                        Debug.Log("no moneeeey");
                        return;
                    }

                    money.Gold -= rowPrice;

                    foreach (GameObject box in row1)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 5)
                {
                    if (money.Gold <= 0)
                    {
                        return;
                    }
                    
                    money.Gold -= rowPrice;

                    foreach (GameObject box in row2)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 4)
                {
                    if (money.Gold <= 0)
                    {
                        return;
                    }

                    money.Gold -= rowPrice;

                    foreach (GameObject box in row3)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 3)
                {
                    if (money.Gold <= 0)
                    {
                        return;
                    }

                    money.Gold -= rowPrice;

                    foreach (GameObject box in row4)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 2)
                {
                    if (money.Gold <= 0)
                    {
                        return;
                    }

                    money.Gold -= rowPrice;

                    foreach (GameObject box in row5)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 1)
                {
                    if (money.Gold <= 0)
                    {
                        return;
                    }

                    money.Gold -= rowPrice;

                    foreach (GameObject box in row6)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                    rowsButton.GetComponent<Button>().interactable = false;
                    child.GetComponent<Text>().color = new Color32(255, 171, 171, 171);
                }
            }
        }
    }

    private void RowsDisabling()
    {
        foreach (GameObject box in row1)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row2)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row3)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row4)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row5)
        {
            box.SetActive(false);
        }
        foreach (GameObject box in row6)
        {
            box.SetActive(false);
        }
    }
}