using UnityEngine;
using UnityEngine.UI;

public class NoUnitSelected : MonoBehaviour
{
    [SerializeField] public Text noUnitSelectedText1;
    [SerializeField] public Text noUnitSelectedText2;
    [SerializeField] public Image noUnitSelectedImage;

    private PauseMenu pauseMenu;
    private Tutorial tutorialMenu;

    private void Start()
    {
        noUnitSelectedText1.enabled = false;
        noUnitSelectedText2.enabled = false;
        noUnitSelectedImage.enabled = false;

        pauseMenu = FindObjectOfType<PauseMenu>();
        tutorialMenu = FindObjectOfType<Tutorial>();
    }

    private void Update()
    {
        if (pauseMenu.pauseActive == true || tutorialMenu.tutorialEnabled == true)
        {
            return;
        }
    }
}
