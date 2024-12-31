using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject resultWindow;
    private bool isGameOver; // 避免場景切換時重複觸發 OnDestroy，加個判斷

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

    // 目前是有人死亡觸發就此函式，只會跳視窗，不會判斷誰輸誰贏
    // 可能要等連線實作後處理
    public void ShowResultWindow()
    {
        if (!isGameOver)
        {
            resultWindow.SetActive(true);
            isGameOver = true;
        }
    }


}
