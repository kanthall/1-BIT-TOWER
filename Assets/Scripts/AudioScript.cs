using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    float sfx;
    float sound;

    public static AudioScript instance;

    SlidersValueController slidersValue;

    void Awake()
    {
        if (AudioScript.instance == null)
        {
            DontDestroyOnLoad(gameObject);
            AudioScript.instance = this;
        }
    }

    private void Start()
    {
        float sfx = PlayerPrefs.GetFloat("sfxPrefs", 1f);
        float sound = PlayerPrefs.GetFloat("soundPrefs", 1f);

        masterMixer.SetFloat("sfx_param", Mathf.Log(sfx) * 10);
        masterMixer.SetFloat("sound_param", Mathf.Log(sfx) * 10);
    }

    public void SetSFXVolume(Slider sliderSfx)
    {
        masterMixer.SetFloat("sfx_param", Mathf.Log(sliderSfx.value) * 10);
        PlayerPrefs.SetFloat("sfxPrefs", sliderSfx.value);
        PlayerPrefs.Save();
    }

    public void SetSoundVolume(Slider sliderSound)
    {
        masterMixer.SetFloat("sound_param", Mathf.Log(sliderSound.value) * 10);
        PlayerPrefs.SetFloat("soundPrefs", sliderSound.value);
        PlayerPrefs.Save();
    }
}