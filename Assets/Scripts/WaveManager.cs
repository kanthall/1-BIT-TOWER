using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] Text waveValue;
    [SerializeField] int startingWave;
    public int wave;

    [Header("Wave button text")]
    [SerializeField] private Text startText;
    [SerializeField] private Text nextWaveText;

    private void Start()
    {
        wave = startingWave;
        waveValue.text = wave.ToString();

        nextWaveText.enabled = false;
    }

    private void Update()
    {
        waveValue.text = "WAVE" + " - " + GetWave().ToString();

        if (wave == startingWave)
        {
            startText.enabled = true;
        }

        else if (wave != startingWave)
        {
            nextWaveText.enabled = true;
            startText.enabled = false;
        }
    }

    public int GetWave()
    {
        return wave;
    }

    public void AddToWaveCounter()
    {
        wave += 1;
    }
}
