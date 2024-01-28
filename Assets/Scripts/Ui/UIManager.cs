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
            print("lose");
        }
        else if (TeacherController.isWin)
        {
            MoneyText.text = "you have" + ScoreManager.MoneyAmount + "money";
            WinText.SetActive(true);
            print("win");
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                
                
               
                
                TeacherController.isWin = false;
                StartCoroutine(Next());
               

            }
            else if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                StartCoroutine(BackToBeginScene());
            }
 
        }

    }

    IEnumerator BackToBeginScene()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(0);
    }

    IEnumerator Next()
    {

        ScoreManager.MoneyAmount = 100;
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(2);
        ScoreManager.iswin = false;
        
    }
}
