using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    public GameObject WinText;
    public GameObject LoseText;
    private void Update()
    {
        if (ScoreManager.IsLose())
        {
            LoseText.SetActive(true);
        }
        else if (TeacherController.isWin)
        {
            WinText.SetActive(true);
        }
        MoneyText.text = "you have" + ScoreManager.MoneyAmount + "money";
    }
}
