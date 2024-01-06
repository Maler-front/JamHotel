using System;
using UnityEngine;

public class WalletModel
{
    public static WalletModel Instance { get; private set; }

    public int Coins { get; private set; }

    public event Action<int> OnCoinsChanged;

    public WalletModel()
    {
        if (Instance == null)
            Instance = this;
    }

    public WalletModel(int startCoins)
    {
        Coins = startCoins;
        if (Instance == null)
            Instance = this;
    }

    public void AddCoins(int value)
    {
        Coins += value;
        OnCoinsChanged?.Invoke(Coins);
    }

    public bool TrySpendCoins(int value)
    {
        if(value > Coins)
            return false;

        Coins -= value;
        OnCoinsChanged?.Invoke(Coins);
        return true;
    }
}
