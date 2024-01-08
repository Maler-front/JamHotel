using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingAudio : MonoBehaviour
{
    [SerializeField] private Sprite _audioOn;
    [SerializeField] private Sprite _audioOff;
    [SerializeField] private Button _buttonAudio;

    [SerializeField] private Slider _sliderAudio;

    [SerializeField] private TMP_Text _levelSoundText;

    [SerializeField] private AudioSource _audioSource;


    private void Start()
    {
        if (_audioSource != null)
        {
            UpdateTextWithValue(_sliderAudio.value);
            _sliderAudio.onValueChanged.AddListener(UpdateTextWithValue);
        }
    }

    private void Update()
    {
        if (_audioSource != null)
        {
            _audioSource.volume = _sliderAudio.value;
        }
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            _buttonAudio.GetComponent<Image>().sprite = _audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            _buttonAudio.GetComponent<Image>().sprite = _audioOn;
        }
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
    }

    void UpdateTextWithValue(float value)
    {
        _levelSoundText.text = (value * 100).ToString("F0");
    }
}
