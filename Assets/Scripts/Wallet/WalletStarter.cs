using UnityEngine;

public class WalletStarter : MonoBehaviour
{
    [SerializeField]
    private WalletView _view;

    private void Awake()
    {
        CreateWalletModel();
    }

    private void Start()
    {
        CreateWalletVP();
    }

    public void CreateWalletModel()
    {
        if(WalletModel.Instance == null)
            new WalletModel();
    }

    public void CreateWalletVP()
    {
        new WalletPresenter(_view);
    }
}
