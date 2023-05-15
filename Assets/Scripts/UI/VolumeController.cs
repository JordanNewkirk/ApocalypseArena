using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    public TMP_Text volumeText = null;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadValues();
    }

    public void VolumeSlider(float number)
    {
        volumeText.text = number.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volume);
        LoadValues();
    }

    void LoadValues()
    {
        float volume = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volume;
        AudioListener.volume = volume;
    }
}
