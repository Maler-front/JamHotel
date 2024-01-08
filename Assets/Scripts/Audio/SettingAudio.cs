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


    private void Start()
    {
        UpdateTextWithValue(_sliderAudio.value);
        _sliderAudio.onValueChanged.AddListener(UpdateTextWithValue);
    }

    private void Update()
    {
        AudioListener.volume = _sliderAudio.value;
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
            _buttonAudio.GetComponent<Image>().sprite = _audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            _buttonAudio.GetComponent<Image>().sprite = _audioOn;
        }
    }

    void UpdateTextWithValue(float value)
    {
        _levelSoundText.text = (value * 100).ToString("F0");
    }
}
