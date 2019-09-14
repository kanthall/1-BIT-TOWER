using UnityEngine;
using UnityEngine.UI;

public class NoUnitSelected : MonoBehaviour
{
    [SerializeField] public Text noUnitSelectedText1;
    [SerializeField] public Text noUnitSelectedText2;
    [SerializeField] public Image noUnitSelectedImage;

    private void Start()
    {
        noUnitSelectedText1.enabled = false;
        noUnitSelectedText2.enabled = false;
        noUnitSelectedImage.enabled = false;
    }
}
