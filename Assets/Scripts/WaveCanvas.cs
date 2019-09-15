using System.Collections;
using UnityEngine;

public class WaveCanvas : MonoBehaviour
{
    [SerializeField] private Canvas waveCanvas;

    private void Start()
    {
        waveCanvas.enabled = false;
    }
    
    public void ShowWarning()        
    {
        StartCoroutine(WaveCanvasEnable());
    }

    private IEnumerator WaveCanvasEnable()
    {
        waveCanvas.enabled = true;
        yield return new WaitForSeconds(2);
        waveCanvas.enabled = false;
    }
}
