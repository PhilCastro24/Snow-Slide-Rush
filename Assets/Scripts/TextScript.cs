using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;
    CoinController coinController;


    void Start()
    {
        CoinText.text = "Coins: " + coinController.coins;
    }


    void Update()
    {
        
    }
}
