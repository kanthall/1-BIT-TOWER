using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoUnitSelected : MonoBehaviour
{
    [SerializeField] public Text noUnitSelectedText;
    [SerializeField] public Image noUnitSelectedImage;

    private void Start()
    {
        noUnitSelectedText.enabled = false;
        noUnitSelectedImage.enabled = false;
    }
}
