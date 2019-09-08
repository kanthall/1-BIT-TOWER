using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] Text waveValue;
    [SerializeField] int startingWave = 1;
    private int wave;
    [SerializeField] private List<WaveConfig> waveConfigs;

    private void Start()
    {
        wave = startingWave;
        waveValue.text = wave.ToString();
    }

    private void Update()
    {
        waveValue.text = "WAVE" + " - " + GetWave().ToString();
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
