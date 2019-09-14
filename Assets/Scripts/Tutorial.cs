using UnityEngine;
 
public class Tutorial : MonoBehaviour
{
    [SerializeField] Canvas tutorial;
    [SerializeField] BoxCollider2D collider2D;
 
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
        }
    }
 
    private void TutorialEnable()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            tutorial.enabled = true;
            collider2D.enabled = true;
        }
       
        else if(Input.GetKeyUp(KeyCode.H))
        {
            tutorial.enabled = false;
            collider2D.enabled = false;
        }
    }
}