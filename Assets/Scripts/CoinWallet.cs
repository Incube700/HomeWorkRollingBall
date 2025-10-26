using System;
using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    [SerializeField] private int _coins;
    public int Coins => _coins;

    public void AddCoins(int coinsToAdd) 
    {
        if (coinsToAdd <= 0)
        {
            return;
        }
        _coins += coinsToAdd;
    }

    public void Clear()
    {
        _coins = 0;
    }
}
   
