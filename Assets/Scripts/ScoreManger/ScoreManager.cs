using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int MoneyAmount = 100;
    public static void AddMoney(int money)
    {
        MoneyAmount += money;
        Debug.Log("add"+money+"  your amount is"+ MoneyAmount);
    }

    public static void MinusMoney(int money)
    {
        MoneyAmount -= money;
    }

    public static bool IsLose()
    {
        if (MoneyAmount<=0)
        {
            return true;
        }

        return false;
    }
}
