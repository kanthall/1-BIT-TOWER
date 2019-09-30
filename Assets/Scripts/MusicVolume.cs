using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField] float musicVolume;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVolume", vol);
        Debug.Log(vol);
        PlayerPrefs.Save();
    }
}
