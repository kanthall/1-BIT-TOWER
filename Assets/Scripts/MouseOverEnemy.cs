using UnityEngine;

public class MouseOverEnemy : MonoBehaviour
{
    [SerializeField] public Canvas statsCanvas;
    private bool statsVisible;

    void Start()
    {
        statsCanvas.enabled = false;
    }

    private void OnMouseOver()
    {
        statsCanvas.enabled = true;
    }

    private void OnMouseExit()
    {
        statsCanvas.enabled = false;
    }
}
