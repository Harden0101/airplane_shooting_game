using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject resultWindow;
    private bool isGameOver; // �קK���������ɭ���Ĳ�o OnDestroy�A�[�ӧP�_

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

    // �ثe�O���H���`Ĳ�o�N���禡�A�u�|�������A���|�P�_�ֿ��Ĺ
    // �i��n���s�u��@��B�z
    public void ShowResultWindow()
    {
        if (!isGameOver)
        {
            resultWindow.SetActive(true);
            isGameOver = true;
        }
    }


}
