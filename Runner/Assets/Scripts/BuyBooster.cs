using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBooster : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    private int _price = 5;
    public static event Action BoostBought;
    

    public void Buy()
    {
        if (CoinLogic.Coins >= _price)
        {
        CoinLogic.Coins -= _price;
        BoostBought?.Invoke();
        }
    }
}
