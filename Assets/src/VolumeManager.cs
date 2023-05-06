using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume") && !PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", -40);
            PlayerPrefs.SetFloat("SFXVolume", -5);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeMusicVolume()
    {
        masterMixer.SetFloat("musicVol", musicSlider.value);
        Save("musicSlider");
    }

    public void ChangeSFXVolume()
    {
        masterMixer.SetFloat("SFXVol", SFXSlider.value);
        Save("SFXSlider");
    }

    private void Save(string slider)
    {
        switch (slider)
        {
            case "musicSlider":
                PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
                break;

            case "SFXSlider":
                PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
                break;
        }
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}