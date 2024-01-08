using System;
using UnityEngine;

public static class WalletModel
{
    public static uint Coins => _coins;

    private static uint _coins = 0;
    private static uint _limit = 1000;

    public static event Action OnCoinsChanged;
    public static event Action OnGameEnded;

    public static void AddCoins(uint value)
    {
        _coins += value;
        OnCoinsChanged?.Invoke();
        
        if(_coins >= _limit)
        {
            OnGameEnded?.Invoke();
        }
    }

    public static bool TrySpendCoins(uint value)
    {
        if(value > _coins)
            return false;

        _coins -= value;
        OnCoinsChanged?.Invoke();
        return true;
    }
}
