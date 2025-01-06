using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public AudioSource clickSE; //因為都是按按鈕切場景我直接寫在這裡
    public void ChangeScene(string sceneName)
    {
        clickSE.Play();
        SceneManager.LoadScene(sceneName);
    }
}
