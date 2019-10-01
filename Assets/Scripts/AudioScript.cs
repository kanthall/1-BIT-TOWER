using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    float sfx;
    float sound;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sfx = PlayerPrefs.GetFloat("sfx_param", 0);
        sound = PlayerPrefs.GetFloat("sound_param", 0);

        Debug.Log(sfx);
        Debug.Log(sound);
    }

    public void SetSFXVolume(Slider slider)
    {
        masterMixer.SetFloat("sfx_param", Mathf.Log(slider.value) * 20);
        PlayerPrefs.SetFloat("sfx_param", slider.value);
        PlayerPrefs.Save();
    }

    public void SetSoundVolume(Slider slider)
    {
        masterMixer.SetFloat("sound_param", Mathf.Log(slider.value) * 20);
        PlayerPrefs.SetFloat("sound_param", slider.value);
        PlayerPrefs.Save();
    }
}