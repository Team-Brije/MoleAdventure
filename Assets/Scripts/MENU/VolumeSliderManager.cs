using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] string volumeType;
    void Start()
    {
        if (!PlayerPrefs.HasKey(volumeType))
        {
            PlayerPrefs.SetFloat(volumeType, 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volumeType);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(volumeType, volumeSlider.value);
    }
}
