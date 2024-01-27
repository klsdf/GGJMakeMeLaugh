using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;

    private void Update()
    {
        MoneyText.text = "you have" + ScoreManager.MoneyAmount + "money";
    }
}
