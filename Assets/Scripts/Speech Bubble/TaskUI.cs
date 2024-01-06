using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private TextMeshProUGUI _num;

    public void UpdateUI(Sprite sprite, byte num)
    {
        _sprite.sprite = sprite;
        _num.text = "x" + num;
    }
}
