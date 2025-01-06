using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject resultWindow;
    private bool isGameOver; // 避免場景切換時重複觸發 OnDestroy，加個判斷

    public AudioSource gameOverSE; 

    void Start()
    {
        isGameOver = false;
        resultWindow.SetActive(false);
        PlayerController.OnPlayerDied += ShowResultWindow;
    }

    void OnDestroy()
    {
        PlayerController.OnPlayerDied -= ShowResultWindow;
    }

    public void ShowResultWindow(string diedPlayer)
    {
        if (!isGameOver)
        {
            resultWindow.SetActive(true);
            TextMeshProUGUI winText = resultWindow.transform.Find("win").GetComponent<TextMeshProUGUI>();
            if (winText != null)
            {
                string winner = "";
                if (diedPlayer == "Player1")
                {
                    winner = "Player 2";
                }
                else if (diedPlayer == "Player2")
                {
                    winner = "Player 1";
                }

                winText.text = winner + " Win!";
            }

            gameOverSE.Play();
            isGameOver = true;
        }
    }


}
