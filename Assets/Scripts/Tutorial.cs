using UnityEngine;
 
public class Tutorial : MonoBehaviour
{
    [SerializeField] Canvas tutorial;
    [SerializeField] BoxCollider2D collider2D;
    [SerializeField] public bool tutorialEnabled;

    private void Start()
    {
        tutorialEnabled = true;
    }

    void Update()
    {
        TutorialEnable();        
    }
 
    private void OnMouseDown()
    {
        if (tutorial.enabled)
        {
            tutorial.enabled = false;
            collider2D.enabled = false;
            tutorialEnabled = false;
        }
    }
 
    private void TutorialEnable()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Time.timeScale = 0;
            tutorial.enabled = true;
            collider2D.enabled = true;
            tutorialEnabled = true;
        }
       
        else if(Input.GetKeyUp(KeyCode.H))
        {
            Time.timeScale = 1;
            tutorial.enabled = false;
            collider2D.enabled = false;
            tutorialEnabled = false;
        }
    }
}