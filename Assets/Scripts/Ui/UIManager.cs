using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
            StartCoroutine(BackToBeginScene());
        }
        else if (TeacherController.isWin)
        {
            WinText.SetActive(true);
            StartCoroutine(BackToBeginScene());
        }
        MoneyText.text = "you have" + ScoreManager.MoneyAmount + "money";
    }

    IEnumerator BackToBeginScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
