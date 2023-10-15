using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text CoinText;
    public int currentCoin = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CoinText.text = "Score: " + currentCoin.ToString();

    }

    public void IncreaseCoin(int v)
    {
        currentCoin += v;
        CoinText.text = "Score: " + currentCoin.ToString();
    }
}
