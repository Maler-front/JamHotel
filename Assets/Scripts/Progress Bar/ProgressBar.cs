using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _progressBar;
    private Slider _slider;
    private float _targetTime = 0;
    private float _currentTime = 0;

    private void Awake() 
    {
        if(!_progressBar.TryGetComponent<Slider>(out _slider))
        {
            Debug.LogWarning("There Is No Slider Component");
        }     
    }

    public void StartTimer(float time)
    {
        // Debug.Log("Start");
        _progressBar.SetActive(true);
        _targetTime = time;
    }

    private void Update() 
    {
        if(_targetTime != 0)
        {
            _currentTime += Time.deltaTime;
            _slider.value = _currentTime / _targetTime;
            
            if(_currentTime >= _targetTime)
            {
                _targetTime = 0;
                _currentTime = 0;
                _progressBar.SetActive(false);
            }
        }
    }
}
