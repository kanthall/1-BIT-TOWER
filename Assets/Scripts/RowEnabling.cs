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

    private GameManagerBehaviour gameManagerBehaviour = null;
    private PlacingUnits placingUnits;
    private int rowPrice = 10;
    [SerializeField] int rowsToBuy = 6;
    [SerializeField] GameObject rowsButton;

    [Header("Sound")] 
    [SerializeField] private AudioClip buyingSound;
    [SerializeField] [Range(0, 1)] float buyingSoundVolume = 0.75f;
    private AudioSource audio;
    
    void Start()
    {
        RowsDisabling();
        gameManagerBehaviour = FindObjectOfType<GameManagerBehaviour>();
        placingUnits = GetComponent<PlacingUnits>();
        audio = GetComponent<AudioSource>();
    }

    public void BuyRow()
    {
        if (rowsToBuy > 0)
        {
            if (gameManagerBehaviour.Gold > rowPrice)
            {
                if (rowsToBuy == 6)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 1");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row1)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 5)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 2");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row2)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 4)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 3");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row3)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 3)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 4");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row4)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 2)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 5");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row5)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
                else if (rowsToBuy == 1)
                {
                    if (gameManagerBehaviour.Gold <= 0)
                    {
                        return;
                    }

                    Debug.Log("Row bought 6");
                    gameManagerBehaviour.Gold -= rowPrice;

                    foreach (GameObject box in row6)
                    {
                        box.SetActive(true);
                        audio.PlayOneShot(buyingSound, buyingSoundVolume);
                    }

                    rowsToBuy -= 1;
                }
            }
        }
    }

    private void Update()
    {
        if (rowsToBuy == 0)
        {
            rowsButton.GetComponent<Button>().interactable = false;
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