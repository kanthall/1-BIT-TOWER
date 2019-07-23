using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoUnitSelected : MonoBehaviour
{
    [SerializeField] public Text noUnitSelectedText;

    private void Start()
    {
        noUnitSelectedText.enabled = false;
    }
}
