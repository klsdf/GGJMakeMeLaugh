using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    public static bool isWin=false;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("isTouched");
            isWin = true;
            player.GetComponent<SmileController>().Smile();
            ScoreManager.iswin = isWin;

            ScoreManager.MoneyAmount = -999999;
        }
    }
}
