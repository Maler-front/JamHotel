using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScreen : MonoBehaviour
{
    private void Awake()
    {
        WalletModel.OnGameEnded += () => { Time.timeScale = 0f; gameObject.SetActive(true); };
        gameObject.SetActive(false);
    }
}
