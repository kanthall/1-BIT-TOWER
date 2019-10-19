using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour
{

    [SerializeField] GameObject button1x;
    [SerializeField] GameObject button2x;
    [SerializeField] GameObject button4x;
    

    private void Start()
    {
        button1x.GetComponent<Image>().color = Color.red;
        button2x.GetComponent<Image>().color = Color.black;
        button4x.GetComponent<Image>().color = Color.black;
    }

    public void Speed1x()
    {
        Time.timeScale = 1f;
        button1x.GetComponent<Image>().color = Color.red;
        button2x.GetComponent<Image>().color = Color.black;
        button4x.GetComponent<Image>().color = Color.black;
    }

    public void Speed2x()
    {
        Time.timeScale = 2f;
        button1x.GetComponent<Image>().color = Color.black;
        button2x.GetComponent<Image>().color = Color.red;
        button4x.GetComponent<Image>().color = Color.black;
    }

    public void Speed4x()
    {
        Time.timeScale = 4f;
        button1x.GetComponent<Image>().color = Color.black;
        button2x.GetComponent<Image>().color = Color.black;
        button4x.GetComponent<Image>().color = Color.red;
    }

    private void Update()
    {
        Keys();  
    }

    private void Keys()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Speed1x();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Speed2x();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed4x();
        }
    }
}
