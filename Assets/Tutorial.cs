using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Canvas tutorial;
    void Update()
    {
        TutorialEnable();
    }

    private void OnMouseDown()
    {
        tutorial.enabled = false;
    }

    private void TutorialEnable()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            tutorial.enabled = true;
        }
        
        else if(Input.GetKeyUp(KeyCode.H))
        {
            tutorial.enabled = false;
        }
    }
}
