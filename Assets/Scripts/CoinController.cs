using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    [SerializeField] int pointsForCoinPickup = 1;
    static int score = 0;
    [SerializeField] TextMeshProUGUI coinsText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log("Coins collected: " + score);
        coinsText.text = "Coins: " + score.ToString();
    }
}
