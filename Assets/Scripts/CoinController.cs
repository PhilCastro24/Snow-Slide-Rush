using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coins = 0;
    

    void Start()
    {
        
    }


    void Update()
    {
        Debug.Log(coins);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IncrementingCoins();
            Destroy(gameObject);
        }
    }

    public void IncrementingCoins(int coinValue = 1)
    {

        coins += coinValue;
    }
}
