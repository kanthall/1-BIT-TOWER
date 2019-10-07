using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersValueController : MonoBehaviour
{

    [SerializeField]Slider sliderSfx;
    [SerializeField]Slider sliderSound;

    private void Start()
    {
        SetSliders();
    }

    public void SetSliders()
    {
        sliderSfx.value = PlayerPrefs.GetFloat("sfxPrefs", 1);
        sliderSound.value = PlayerPrefs.GetFloat("soundPrefs", 1);
    }
}
