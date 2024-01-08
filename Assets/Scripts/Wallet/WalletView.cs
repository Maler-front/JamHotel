using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMesh;

    private void Awake() 
    {
        WalletModel.OnCoinsChanged += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        _textMesh.text = WalletModel.Coins.ToString();
    }
}
