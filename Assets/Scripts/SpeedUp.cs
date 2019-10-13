using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    public void Speed2x()
    {
        Time.timeScale = 2f; 
    }

    public void Speed1x()
    {
        Time.timeScale = 1f;
    }
}
