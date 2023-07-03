using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalityBoost : MonoBehaviour
{
    public static event Action BoostTaken;

    private void OnEnable()
    {
        BuyBooster.BoostBought += OnTakeBoost;
    }

    private void OnDisable()
    {
        BuyBooster.BoostBought -= OnTakeBoost;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTakeBoost();
        print("boost activated");
    }

    private void OnTakeBoost()
    {
        BoostTaken?.Invoke();
        print("boost activated");

    }
}
