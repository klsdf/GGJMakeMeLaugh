using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEatCoin();
        }
    }
    private void OnEatCoin()
    {
        ScoreManager.AddMoney(Value);
        Destroy(gameObject);
    }
}
