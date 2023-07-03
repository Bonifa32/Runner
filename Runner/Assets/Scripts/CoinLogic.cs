using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinText;
    public static int Coins = 0;

    private void Update()
    {
        _coinText.text = "Coins: " + Coins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coins++;       
        print(Coins);
        gameObject.SetActive(false);
    }
}
